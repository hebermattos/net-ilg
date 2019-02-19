using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class Salesman
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }

        public Salesman(string rawCustomer)
        {
            var customerData = rawCustomer.Split('ç');

            if (customerData[0] != "001")
                throw new ArgumentException("Invalid salesman data");

            CPF = customerData[1];
            Name = customerData[2];
            Salary = customerData[3];
        }
    }
}
