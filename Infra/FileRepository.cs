using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Infra
{
    public class FileRepository : IDataRepository
    {
        public IEnumerable<string> GetData()
        {
            var fullRawData = new ConcurrentBag<string>();

            const int BufferSize = 32;

            Parallel.ForEach(Directory.EnumerateFiles(FolderPath.GetInFolderPath(), "*.dat"), (file) =>
            {
                using (var fileStream = File.OpenRead(file))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
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
