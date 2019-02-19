using System;

namespace Domain.Data
{
    class Customer
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }

        public Customer(string rawCustomer)
        {
            var customerData = rawCustomer.Split('ç');

            if (customerData[0] != "002")            
                throw new ArgumentException("Invalid customer data");            

            CNPJ = customerData[1];
            Name = customerData[2];
            BusinessArea = customerData[3];
        }
    }
}
