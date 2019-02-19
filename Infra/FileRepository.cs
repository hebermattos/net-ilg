using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Infra
{
    public class FileRepository : IDataRepository
    {
        public IEnumerable<string> GetData()
        {
            var fullRawData = new List<string>();

            foreach (string file in Directory.EnumerateFiles(FolderPath.GetInFolderPath(), "*.dat"))
            {
                const int BufferSize = 128;

                using (var fileStream = File.OpenRead(file))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                        fullRawData.Add(line);
                }

            }

            return fullRawData;
        }
    }
}
