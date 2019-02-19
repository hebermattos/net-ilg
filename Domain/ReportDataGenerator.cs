using System.Collections.Generic;

namespace Domain
{
    public abstract class ReportDataGenerator
    {
        public abstract string Key { get; }

        protected abstract string Generate(List<string> rawData);

        public ReportData GetData(List<string> rawData)
        {
            var value = Generate(rawData);

            return new ReportData { Key = Key, Value = value };
        }
    }
}
