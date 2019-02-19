using Domain;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class AmountClientTest
    {
        private static object[] data = {
                                  new object[] {new List<string> { "001ç1234567891234çDiegoç50000", } ,"0"},
                                  new object[] {new List<string> { "001ç1234567891234çDiegoç50000", "002ç2345675434544345çJose da SilvaçRural" } ,"1"},
                                  new object[] {new List<string> { "001ç1234567891234çDiegoç50000", "002ç2345675434544345çJose da SilvaçRural", "002ç2345675434544345çJose da SilvaçRural", "002ç2345675433444345çEduardo PereiraçRural" }, "2"}
                                };

        [Test, TestCaseSource("data")]
        public void GenerateReport(List<string> data, string expected)
        {
            var report = new AmountClient();

            var actual = report.GetData(data).Value;

            Assert.AreEqual(expected, actual);
        }
    }
}


