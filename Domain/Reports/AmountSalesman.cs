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
            var salesmenCount = rawData
                .Where(x => x.StartsWith("001"))
                .Select(x => new Salesman(x))
                .GroupBy(x => x.CPF)
                .Count();

            return salesmenCount.ToString();
        }
    }
}
