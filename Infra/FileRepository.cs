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
        public List<string> GetData()
        {
            var fullRawData = new List<string>();

            foreach (string file in Directory.EnumerateFiles(FolderPath.GetInFolderPath(), "*.dat"))
            {
                var lines = File.ReadAllText(file).Split(
                         new[] { Environment.NewLine },
                         StringSplitOptions.None
                     );

                fullRawData.AddRange(lines);
            }

            return fullRawData;
        }


    }
}
