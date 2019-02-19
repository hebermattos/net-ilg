using Domain;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var datas = _dataRepository.GetData();

            var processedData = new List<ProcessedData>();

            foreach (var data in datas)
            {
                var result = data.ProcessData();

                processedData.Add(result);
            }
        }
    }
}
