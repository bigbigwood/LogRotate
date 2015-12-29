using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foundation.zip
{
    public interface IZipper
    {
        bool Zip(string zippedFileName, List<string> fileNames);
        bool Zip(string zippedFileName, string fileName);
        bool UnZip(string zippedFileName, List<string> unzippedfileNames);
        bool UnZip(string zippedFileName, string unzippedfileName);
    }
}
