using Domain;
using Infra;
using System;
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
            var rawReportDatas = _dataRepository.GetData();

            var processors = new List<ReportDataGenerator>
            {
                new AmountClient(),
                new AmountSalesman()
            };

            var processedReportDatas = new List<string>();

            foreach (var processor in processors)
            {
                var data = processor.GetData(rawReportDatas);

                processedReportDatas.Add(data.Key + ": " + data.Value);
            }

            System.IO.File.WriteAllLines(FolderPath.GetOutFolderPath() + "\\" + GenerateFileName() + ".done.data", processedReportDatas);

        }

        private static string GenerateFileName()
        {
            return "report_" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}