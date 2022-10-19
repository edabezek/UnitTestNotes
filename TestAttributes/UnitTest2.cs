
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace TestAttributes
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod,Description("Bu bir karekök testi yapan metotdur.")]
        public void TestMethod1()
        {
            Assert.AreEqual(1,1);
        }
        [TestMethod,Ignore]
        public void TestMethod2()
        {
            Assert.AreEqual(1, 1);
        }
        [TestMethod,Timeout(1000)]
        public void TestMethod3()
        {
            //Sistemi uyutursak failie düşecek
            Thread.Sleep(1500);
            Assert.AreEqual(1, 1);
        }
        [TestMethod,Ignore]
        public void TestMethod4()
        {
            Assert.AreEqual(1, 1);
        }
        [TestMethod,Timeout(TestTimeout.Infinite)]//süreyi sonsuz da verebiliriz (int max değeri)
        public void TestMethod5()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
