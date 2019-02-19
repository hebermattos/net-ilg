using Domain.Data;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Reports
{
    public class WorstSalesmanEver : ReportDataGenerator
    {
        public override string Key
        {
            get
            {
                return "Worst salesman ever";
            }
        }

        protected override string Generate(IEnumerable<string> rawData)
        {               
            var saleman = rawData
                .Where(x => x.StartsWith("003"))
                .Select(x => new Sale(x))
                .GroupBy(x => x.SalesmanName)
                .Select(x => new SalesmanTotalSale
                {
                    SalesmanName = x.Key,
                    TotalSaleValue = x.Sum(y => y.CalculateValue())
                })
                .OrderBy(x => x.TotalSaleValue)
                .First()
                .SalesmanName;

            return saleman;
        }        
    }

    struct SalesmanTotalSale
    {
        public string SalesmanName { get; set; }
        public decimal TotalSaleValue { get; set; }
    }
}
