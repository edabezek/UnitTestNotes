using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinnesLayer.DataDrivenUnitTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        //değerleri yakalayabilmek için test context'i yazacağız
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "Kullanıcılar.xml",
            "Kullanici",DataAccessMethod.Sequential)]//xml , connection string folder name veriyoruz ,table name satır ismimiz,verileri karışık(Random) yada sıralı(Sequential) işleneceğini belirtiyoruz.
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV")]
        [TestMethod]
        public void DataTest()//buradaki test xml'deki her satır için çalışacak
        {
            var managerInstance = new KullaniciManager();

            var name = TestContext.DataRow["ad"].ToString();
            var phone = TestContext.DataRow["telefon"].ToString();
            var email = TestContext.DataRow["mail"].ToString();

            var result = managerInstance.KullaniciEkle(name, phone, email);//parametreler , satırdan gelecek

            Assert.IsTrue(result); 
        }
    }
}
