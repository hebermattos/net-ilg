using Domain.Reports;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class WorstSalesmanEverTest
    {
        private static object[] data = {
                                  new object[] {new List<string> { "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çDiego" } ,"Diego"},
                                  new object[] {new List<string> { "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro", "003ç11ç[1-10-101,2-30-2.50,3-40-3.10]çDiego" } ,"Pedro"},
                                  new object[] {new List<string> { "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro", "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro", "003ç10ç[1-10-100,2-30-2.50,3-40-3.10]çPedro", "003ç11ç[1-10-101,2-30-2.50,3-40-3.10]çDiego" } ,"Diego"},
        };

        [Test, TestCaseSource("data")]
        public void GenerateReport(List<string> data, string expected)
        {
            var report = new WorstSalesmanEver();

            var actual = report.GetData(data).Value;

            Assert.AreEqual(expected, actual);
        }
    }
}


