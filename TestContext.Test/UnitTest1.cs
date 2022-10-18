using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestContextDemo.Test
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void TestInitialize()
        {
            TestContext.WriteLine("--Test Initialize--\n");
            TestContext.WriteLine("Test Adı : {0}", TestContext.TestName);
            TestContext.WriteLine("Testin Durumu : {0}", TestContext.CurrentTestOutcome);
            //key yadımıyla bilgi saklayabiliriz.
            TestContext.Properties["bilgi"] = "Hi";
        }
        [TestCleanup]//passed diye berlittiği için başarısız testleri burada görüntüleyebiliriz.
        public void TestCleanup()
        {
            TestContext.WriteLine("--Test Cleanup--\n");
            TestContext.WriteLine("Test Adı : {0}", TestContext.TestName);
            TestContext.WriteLine("Testin Durumu : {0}", TestContext.CurrentTestOutcome);
            TestContext.WriteLine("Test Bilgi : {0}", TestContext.Properties["bilgi"]);
        }
        [TestMethod]
        public void TestMethod1()
        {
            TestContext.WriteLine("--Test method1--");//output ekranında yazar
            TestContext.WriteLine("Test Adı : {0}",TestContext.TestName);
            TestContext.WriteLine("Testin Durumu : {0}",TestContext.CurrentTestOutcome);
            TestContext.WriteLine("Testin Sınıfı : {0}",TestContext.FullyQualifiedTestClassName);
            TestContext.WriteLine("Test Bilgi : {0}", TestContext.Properties["bilgi"]);

            Assert.AreEqual(1,1);
        }
    }
}
