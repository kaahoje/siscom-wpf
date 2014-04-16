using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Util.FileSystem
{
    public class FileInfo
    {
        public static Dictionary<string, string> GetListFileInfo(string dir, Dictionary<string, string> distFiles)
        {
            var files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                var fileInfo = FileVersionInfo.GetVersionInfo(file);
                distFiles.Add(file.Replace(dir, ""), fileInfo.FileVersion);
            }
            var diretorios = Directory.GetDirectories(dir);
            return diretorios.Aggregate(distFiles, (current, diretorio) => GetListFileInfo(diretorio, current));
        }
    }
}
