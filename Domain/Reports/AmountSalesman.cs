using Domain.Data;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class AmountSalesman : ReportDataGenerator
    {
        public override string Key
        {
            get
            {
                return "Amount of salesman";
            }
        }

        protected override string Generate(IEnumerable<string> rawData)
        {
            var rawSalesmen = rawData.Where(x => x.StartsWith("001"));

            var salesmen = rawSalesmen.Select(x => new Salesman(x)); 

            var salesmenCount = salesmen.GroupBy(x => x.CPF).Count();

            return salesmenCount.ToString();
        }
    }
}
