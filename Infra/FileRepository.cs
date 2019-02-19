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
        public IEnumerable<string> GetData()
        {
            var fullRawData = new ConcurrentBag<string>();

            var bufferSize = Convert.ToInt32(ConfigurationManager.AppSettings["bufferSize"]);

            Parallel.ForEach(Directory.EnumerateFiles(FolderPath.GetInFolderPath(), "*.dat"), (file) =>
            {
                using (var fileStream = File.OpenRead(file))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                        fullRawData.Add(line);
                }
            });


            return fullRawData;
        }
    }
}
