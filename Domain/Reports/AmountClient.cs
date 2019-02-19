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
            return "123";
        }
    }
}
