using Domain.Data;
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
            var rawCustomers = rawData.Where(x => x.StartsWith("002"));

            var customers = rawCustomers.Select(x => new Customer(x));

            var customersCount = customers.GroupBy(x => x.CNPJ).Count();

            return customersCount.ToString();
        }
    }
}
