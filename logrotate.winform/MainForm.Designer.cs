namespace logrotate.winform
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lab_IgnoreFileRange = new System.Windows.Forms.Label();
            this.lab_Action = new System.Windows.Forms.Label();
            this.lab_Folder = new System.Windows.Forms.Label();
            this.tb_KeepNumber = new System.Windows.Forms.TextBox();
            this.tb_folders = new System.Windows.Forms.TextBox();
            this.cb_KeepUnit = new System.Windows.Forms.ComboBox();
            this.cb_Action = new System.Windows.Forms.ComboBox();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lab_IgnoreFileRange
            // 
            this.lab_IgnoreFileRange.AutoSize = true;
            this.lab_IgnoreFileRange.Location = new System.Drawing.Point(13, 22);
            this.lab_IgnoreFileRange.Name = "lab_IgnoreFileRange";
            this.lab_IgnoreFileRange.Size = new System.Drawing.Size(41, 17);
            this.lab_IgnoreFileRange.TabIndex = 0;
            this.lab_IgnoreFileRange.Text = "Keep";
            // 
            // lab_Action
            // 
            this.lab_Action.AutoSize = true;
            this.lab_Action.Location = new System.Drawing.Point(311, 22);
            this.lab_Action.Name = "lab_Action";
            this.lab_Action.Size = new System.Drawing.Size(55, 17);
            this.lab_Action.TabIndex = 1;
            this.lab_Action.Text = "Action: ";
            // 
            // lab_Folder
            // 
            this.lab_Folder.AutoSize = true;
            this.lab_Folder.Location = new System.Drawing.Point(13, 66);
            this.lab_Folder.Name = "lab_Folder";
            this.lab_Folder.Size = new System.Drawing.Size(59, 17);
            this.lab_Folder.TabIndex = 2;
            this.lab_Folder.Text = "Folders:";
            // 
            // tb_KeepNumber
            // 
            this.tb_KeepNumber.Location = new System.Drawing.Point(60, 19);
            this.tb_KeepNumber.Name = "tb_KeepNumber";
            this.tb_KeepNumber.Size = new System.Drawing.Size(47, 22);
            this.tb_KeepNumber.TabIndex = 3;
            // 
            // tb_folders
            // 
            this.tb_folders.Location = new System.Drawing.Point(16, 100);
            this.tb_folders.Multiline = true;
            this.tb_folders.Name = "tb_folders";
            this.tb_folders.Size = new System.Drawing.Size(477, 185);
            this.tb_folders.TabIndex = 5;
            // 
            // cb_KeepUnit
            // 
            this.cb_KeepUnit.FormattingEnabled = true;
            this.cb_KeepUnit.Items.AddRange(new object[] {
            "days",
            "weeks"});
            this.cb_KeepUnit.Location = new System.Drawing.Point(113, 19);
            this.cb_KeepUnit.Name = "cb_KeepUnit";
            this.cb_KeepUnit.Size = new System.Drawing.Size(91, 24);
            this.cb_KeepUnit.TabIndex = 6;
            // 
            // cb_Action
            // 
            this.cb_Action.FormattingEnabled = true;
            this.cb_Action.Items.AddRange(new object[] {
            "7z",
            "Remove"});
            this.cb_Action.Location = new System.Drawing.Point(372, 19);
            this.cb_Action.Name = "cb_Action";
            this.cb_Action.Size = new System.Drawing.Size(121, 24);
            this.cb_Action.TabIndex = 7;
            // 
            // btn_Execute
            // 
            this.btn_Execute.Location = new System.Drawing.Point(381, 302);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(112, 44);
            this.btn_Execute.TabIndex = 8;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 354);
            this.Controls.Add(this.btn_Execute);
            this.Controls.Add(this.cb_Action);
            this.Controls.Add(this.cb_KeepUnit);
            this.Controls.Add(this.tb_folders);
            this.Controls.Add(this.tb_KeepNumber);
            this.Controls.Add(this.lab_Folder);
            this.Controls.Add(this.lab_Action);
            this.Controls.Add(this.lab_IgnoreFileRange);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "logrotate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_IgnoreFileRange;
        private System.Windows.Forms.Label lab_Action;
        private System.Windows.Forms.Label lab_Folder;
        private System.Windows.Forms.TextBox tb_KeepNumber;
        private System.Windows.Forms.TextBox tb_folders;
        private System.Windows.Forms.ComboBox cb_KeepUnit;
        private System.Windows.Forms.ComboBox cb_Action;
        private System.Windows.Forms.Button btn_Execute;
    }
}

