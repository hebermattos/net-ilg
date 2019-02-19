using Domain;
using Infra;
using System.Collections.Generic;

namespace App
{
    public class ReportService
    {
        private IDataRepository _dataRepository;

        public ReportService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void GenerateReport()
        {
            var rawDatas = _dataRepository.GetData();

            var processors = new List<ReportDataGenerator>
            {
                new AmountClient()
            };

            var reportData = new List<string>();

            foreach (var processor in processors)
            {
                var data = processor.GetData(rawDatas);

                reportData.Add(data.Key + ": " + data.Value);
            }

            System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", reportData);

        }
    }
}