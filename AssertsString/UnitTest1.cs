using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace AssertsString
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringContainsTest()
        {
            StringAssert.Contains("Test dünyasindan mrhb", "yes");
        }
        [TestMethod]
        public void StringMatchesTest()
        {
            StringAssert.Matches("Test dünyasindan mrhb", new Regex(@"[a-zA-z]"));
            StringAssert.DoesNotMatch("Test dünyasindan mrhb", new Regex(@"[0-9]"));
        }
        [TestMethod]
        public void StartWithTest()
        {
            StringAssert.StartsWith("Test dünyasindan mrhb", "Test");
        }
        [TestMethod]
        public void EndsWithTest()
        {
            StringAssert.EndsWith("Test dünyasindan mrhb", "mrb");
        }
    }
}
