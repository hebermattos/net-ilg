using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reports
{
    public class MostExpensiveSale : ReportDataGenerator
    {
        public override string Key
        {
            get
            {
                return "Most expensive sale";
            }
        }

        protected override string Generate(IEnumerable<string> rawData)
        {
            var rawSales = rawData.Where(x => x.StartsWith("003"));

            var sales = rawSales.Select(x => new Sale(x));

            var mostExpensiveSale = sales
                .OrderByDescending(x => x.CalculateValue())
                .First()
                .SaleID;

            return mostExpensiveSale;
        }
    }
}
