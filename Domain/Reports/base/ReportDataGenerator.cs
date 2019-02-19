using System.Collections.Generic;

namespace Domain.Reports
{
    public abstract class ReportDataGenerator
    {
        public abstract string Key { get; }

        protected abstract string Generate(IEnumerable<string> rawData);

        public ReportData GetData(IEnumerable<string> rawData)
        {
            var value = Generate(rawData);

            return new ReportData { Key = Key, Value = value };
        }
    }
}
