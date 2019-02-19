using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Configuration;
using System;

namespace Infra
{
    public class FileRepository : IDataRepository
    {
        public IEnumerable<string> GetRawData()
        {
            var fullRawData = new ConcurrentBag<string>();

            Parallel.ForEach(Directory.EnumerateFiles(FolderPath.GetInFolderPath(), "*.dat"), (file) =>
            {
                ExtractFileData(file, fullRawData);
            });

            return fullRawData;
        }

        private static void ExtractFileData(string file, ConcurrentBag<string> fullRawData)
        {
            using (var fileStream = File.OpenRead(file))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, Convert.ToInt32(ConfigurationManager.AppSettings["bufferSize"])))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                    fullRawData.Add(line.Trim());
            }
        }

        public void SaveReport(IEnumerable<string> report)
        {
            StringBuilder stringbuilder = new StringBuilder();

            foreach (var data in report)
            {
                stringbuilder.Append(data);
                stringbuilder.Append(Environment.NewLine);
            }

            File.AppendAllText(FolderPath.GetOutFolderPath() + "\\" + GenerateFileName() + ".done.dat", stringbuilder.ToString());
        }

        private static string GenerateFileName()
        {
            return "report_" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
