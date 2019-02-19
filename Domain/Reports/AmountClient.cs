using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override string Generate(List<string> rawData)
        {
            var rawCustomers = rawData.Where(x => x.StartsWith("002"));

            var customers = new List<Customer>();

            foreach (var rawCustomer in rawCustomers)
            {
                var customerData = rawCustomer.Split('ç');

                customers.Add(new Customer(rawCustomer));
            }

            var customersCount = customers.GroupBy(x => x.CNPJ).Count();

            return customersCount.ToString();
        }
    }
}
