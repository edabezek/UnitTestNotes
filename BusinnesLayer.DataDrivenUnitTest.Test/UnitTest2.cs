using System.Configuration;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinnesLayer.DataDrivenUnitTest.Test
{
    [TestClass]
    public class UnitTest2
    {
        public TestContext TestContext { get; set; }
        [DataSource("MyDataSource"),TestMethod] //app.config'deki xml conf geliyor
        public void DataTest2()
        {
            var manager = new IslemManager();

            int x = (int)Convert.ToUInt32(TestContext.DataRow["x"]);
            int y = (int)Convert.ToUInt32(TestContext.DataRow["y"]);    
            int beklenen = (int)Convert.ToUInt32(TestContext.DataRow["beklenen"]);

            int gerceklesen = manager.Topla(x, y);

            Assert.AreEqual(beklenen, gerceklesen);
        }
    }
}
