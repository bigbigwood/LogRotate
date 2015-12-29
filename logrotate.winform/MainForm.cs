using foundation.zip;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logrotate.winform
{
    public partial class MainForm : Form
    {
        private readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public MainForm()
        {
            InitializeComponent();

            LoadLastConfig();
        }

        public void LoadLastConfig()
        {
            string keepNumber = ConfigurationManager.AppSettings.Get("KeepNumber");
            string keepUnit = ConfigurationManager.AppSettings.Get("KeepUnit");
            string action = ConfigurationManager.AppSettings.Get("Action");
            string folders = ConfigurationManager.AppSettings.Get("Folders");

            tb_KeepNumber.Text = keepNumber;
            cb_KeepUnit.SelectedItem = keepUnit;
            cb_Action.SelectedItem = action;

            string[] folderLines = folders.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries);
            tb_folders.Text = string.Join("\r\n", folderLines);
        }

        private void btn_Execute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_KeepNumber.Text))
            {
                MessageBox.Show("please input keep number");
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_folders.Text))
            {
                MessageBox.Show("please input folders to be watch..");
                return;
            }

            List<FileInfo> rotateFiles = new List<FileInfo>();
            int keepDays = int.Parse(tb_KeepNumber.Text) * (cb_KeepUnit.SelectedItem.ToString() == "days" ? 1 : 7);
            string[] folders = tb_folders.Text.Split(new[] { ";", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var fullpath in folders)
            {
                var rotateFilesInFolder = SelectMatchFiles(keepDays, GetFilesFromPath(fullpath));
                rotateFiles.AddRange(rotateFilesInFolder);
            }

            EAction action = cb_Action.SelectedItem.ToString() == "7z" ? EAction.SevenZip : EAction.Remove;
            Log.InfoFormat("Execute with config: keepDays = {0}, action = {1}, Folders = {2}", keepDays, action, string.Join(";", folders));

            switch(action)
            {
                case EAction.SevenZip:
                    {
                        IZipper zipper = new SevenZipper();
                        foreach(var fileinfo in rotateFiles)
                        {
                            if (fileinfo.Extension == ".7z") continue;

                            Log.InfoFormat("Processing file={0}.", fileinfo.FullName);

                            bool bZipResult = zipper.Zip(fileinfo.FullName + ".7z", fileinfo.FullName);
                            Log.InfoFormat("zip result={0}.", bZipResult);
                            
                            if (bZipResult)
                            {
                                Log.Info("deleting original file..");
                                SafeDeleteFile(fileinfo.FullName);
                            }
                        }
                    }
                    break;
                case EAction.Remove:
                    {
                        foreach (var fileinfo in rotateFiles)
                        {
                            Log.InfoFormat("deleting file={0}.", fileinfo.FullName);
                            SafeDeleteFile(fileinfo.FullName);
                        }
                    }
                    break;
                default: 
                    break;
            }

            MessageBox.Show("Process successful!");
        }

        private List<FileInfo> GetFilesFromPath(string path)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(path);
            return TheFolder.GetFiles().ToList();
        }

        private List<FileInfo> SelectMatchFiles(int keepDays, List<FileInfo> files)
        {
            var rotateFiles = files.Where(f => f.LastWriteTime.AddDays(keepDays) < DateTime.Now).ToList();
            return rotateFiles;
        }

        private void SafeDeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!config.HasFile)
            {
                throw new ArgumentException("config file is missing");
            }

            string[] folderLines = tb_folders.Text.Split(new[] { ";", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            SaveSingleConfigItem(config, "KeepNumber", tb_KeepNumber.Text);
            SaveSingleConfigItem(config, "KeepUnit", cb_KeepUnit.SelectedItem.ToString());
            SaveSingleConfigItem(config, "Action", cb_Action.SelectedItem.ToString());
            SaveSingleConfigItem(config, "Folders", string.Join(";", folderLines));

            config.Save(ConfigurationSaveMode.Modified);
        }

        private static void SaveSingleConfigItem(Configuration config, string key, string value)
        {
            KeyValueConfigurationElement element = config.AppSettings.Settings[key];
            if (element == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;
        }
    }
}
