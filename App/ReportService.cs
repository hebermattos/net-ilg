using Domain;
using Domain.Reports;
using Infra;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                new AmountSalesman(),
                new MostExpensiveSale(),
            };

            var processedReportDatas = new ConcurrentBag<string>();

            Parallel.ForEach(processors, (processor) =>
            {
                var data = processor.GetData(rawReportDatas);

                processedReportDatas.Add(data.Key + ": " + data.Value);
            });

            var processedOrderedReportDatas = processedReportDatas.OrderBy(x => x);

            System.IO.File.WriteAllLines(FolderPath.GetOutFolderPath() + "\\" + GenerateFileName() + ".done.data", processedOrderedReportDatas);

        }

        private static string GenerateFileName()
        {
            return "report_" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}