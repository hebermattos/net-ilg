using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.IO;

namespace Infra
{
    public class FileRepository : IDataRepository
    {
        public string GetData()
        {
            var homeDrive = Environment.GetEnvironmentVariable("HOMEDRIVE");
            var homePath = Environment.GetEnvironmentVariable("HOMEPATH");

            var folderPath = homeDrive + "\\" + homePath + "\\Data\\In";

            var fullRawData = new StringBuilder();

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.dat"))
            {
                fullRawData.Append(File.ReadAllText(file));
            }

            return fullRawData.ToString();
        }
    }
}
