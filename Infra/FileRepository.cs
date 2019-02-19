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
        public List<Data> GetData()
        {
            string text = File.ReadAllText(@"c:\file.txt", Encoding.UTF8);

            return new List<Data>();
        }
    }
}
