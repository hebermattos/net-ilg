using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override string Generate(List<string> rawData)
        {
            var rawSalesmen = rawData.Where(x => x.StartsWith("001"));

            var salesmen = new List<Salesman>();

            foreach (var rawSalesman in rawSalesmen)
            {
                salesmen.Add(new Salesman(rawSalesman));
            }

            var salesmenCount = salesmen.GroupBy(x => x.CPF).Count();

            return salesmenCount.ToString();
        }
    }
}
