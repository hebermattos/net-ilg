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

            var epoch = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            System.IO.File.WriteAllLines(FolderPath.GetOutFolderPath() + "\\report_" + epoch + ".done.data", reportData);

        }
    }
}