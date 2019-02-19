using Domain;
using Domain.Reports;
using Infra;
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
            var rawReportDatas = _dataRepository.GetRawData();

            var processors = new List<ReportDataGenerator>
            {
                new AmountClient(),
                new AmountSalesman(),
                new MostExpensiveSale(),
                new WorstSalesmanEver(),
            };

            var processedReportDatas = new ConcurrentBag<string>();

            Parallel.ForEach(processors, (processor) =>
            {
                var data = processor.GetData(rawReportDatas);

                processedReportDatas.Add(data.Key + ": " + data.Value);
            });

            var processedOrderedReportDatas = processedReportDatas.OrderBy(x => x);

            _dataRepository.SaveReport(processedOrderedReportDatas);
        }

    }
}