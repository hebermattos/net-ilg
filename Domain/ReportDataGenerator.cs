using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class ReportDataGenerator
    {
        public abstract string Key { get; }

        protected abstract string Generate(string rawData);

        public ReportData GetData(string rawData)
        {
            var value = Generate(rawData);

            return new ReportData { Key = Key, Value = value };
        }
    }
}
