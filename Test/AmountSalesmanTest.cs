using Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class AmountSalesmanTest
    {
        private static object[] data = {
                                  new object[] {new List<string> { "002ç2345675434544345çJose da SilvaçRural" } ,"0"},
                                  new object[] {new List<string> { "001ç1234567891234çDiegoç50000", "002ç2345675434544345çJose da SilvaçRural", "002ç2345675433444345çEduardo PereiraçRural" }, "1"},
                                  new object[] {new List<string> { "001ç1234567891234çDiegoç50000", "001ç3245678865434çRenatoç40000.99", "002ç2345675433444345çEduardo PereiraçRural" }, "2"}
        };

        [Test, TestCaseSource("data")]
        public void GenerateReport(List<string> data, string expected)
        {
            var report = new AmountSalesman();

            var actual = report.GetData(data).Value;

            Assert.AreEqual(expected, actual);
        }
    }
}


