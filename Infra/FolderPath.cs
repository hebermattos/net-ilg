using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public static class FolderPath
    {
        private static string GetFolderPath()
        {
            var homeDrive = Environment.GetEnvironmentVariable("HOMEDRIVE");
            var homePath = Environment.GetEnvironmentVariable("HOMEPATH");

            var folderPath = homeDrive + "\\" + homePath + "\\Data";
            return folderPath;
        }

        public static string GetInFolderPath()
        {
            return GetFolderPath() + "\\In";
        }

        public static string GetOutFolderPath()
        {
            return GetFolderPath() + "\\Out";
        }
    }
}
