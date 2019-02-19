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
    public class AmountClientTest
    {
        private static object[] data = {
                                  new object[] {new List<string> {"asdasd"} ,1},
                                  new object[] {new List<string> {"asdasd", "asdasdasdas"}, 2}
                                };

        [Test, TestCaseSource("data")]
        public void GenerateReport(List<string> data, int expected)
        {
            var report = new AmountClient();

            var actual = report.GetData(data).Value;

            Assert.AreEqual(expected, actual);
        }
    }
}
