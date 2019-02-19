using Domain.Data;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class DataTest
    {
        [Test, TestCase("001ç1234567891234çDiegoç50000", "1234567891234", "Diego", "50000")]
        public void SalesmanTest(string data, string cpf, string name, string salary)
        {
            var salesman = new Salesman(data);

            Assert.AreEqual(cpf, salesman.CPF);
            Assert.AreEqual(name, salesman.Name);
            Assert.AreEqual(salary, salesman.Salary);
        }

        [Test, TestCase("002ç2345675434544345çJose da SilvaçRural", "2345675434544345", "Jose da Silva", "Rural")]
        public void CustomerTest(string data, string cnpj, string name, string businessArea)
        {
            var customer = new Customer(data);

            Assert.AreEqual(cnpj, customer.CNPJ);
            Assert.AreEqual(name, customer.Name);
            Assert.AreEqual(businessArea, customer.BusinessArea);
        }

        [Test, TestCase("003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çDiego", "10", "Diego")]
        public void SaleTest(string data, string id, string name)
        {
            var sale = new Sale(data);

            Assert.AreEqual(id, sale.SaleID);
            Assert.AreEqual(name, sale.SalesmanName);
        }
    }
}


