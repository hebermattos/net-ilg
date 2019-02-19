using Domain.Data;
using Domain.Reports;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class AmountClient : ReportDataGenerator
    {
        public override string Key
        {
            get
            {
                return "Amount of clients";
            }
        }

        protected override string Generate(IEnumerable<string> rawData)
        {          
            var customersCount = rawData
                .Where(x => x.StartsWith("002"))
                .Select(x => new Customer(x))
                .GroupBy(x => x.CNPJ)
                .Count();

            return customersCount.ToString();
        }
    }
}
