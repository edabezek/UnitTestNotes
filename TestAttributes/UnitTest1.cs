
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestAttributes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Owner("Eda")]
        [TestCategory("Tester")]
        [Priority(1)]
        [TestProperty("Güncelleyen","Engin")]
        public void TestMethod1()
        {
            Assert.AreEqual(1,1);
        }
        [TestMethod]
        [Owner("Eda")]
        [TestCategory("Tester")]
        [Priority(1)]
        [TestProperty("Güncelleyen", "Engin")]
        public void TestMethod2()
        {
            Assert.AreEqual(1, 1);
        }
        [TestMethod]
        [Owner("Eda")]
        [TestCategory("Developer")]
        [TestCategory("Tester")]
        [TestCategory("Demo")]
        [Priority(2)]
        [TestProperty("Güncelleyen", "Engin")]
        [TestProperty("Güncelleyen2", "Ahmet")]
        public void TestMethod3()
        {
            Assert.AreEqual(1, 1);
        }
        [TestMethod]
        [Owner("Engin")]
        [TestCategory("Developer")]
        [Priority(2)]
        public void TestMethod4()
        {
            Assert.AreEqual(1, 1);
        }
        [TestMethod]
        [Owner("Salih")]
        [TestCategory("Developer")]
        [Priority(1)]
        public void TestMethod5()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
