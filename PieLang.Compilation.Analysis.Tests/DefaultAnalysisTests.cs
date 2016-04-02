using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PieLang.Compilation.Analysis.Tests.Properties;
using PieLang.Compilation.Analysis.Tokens;

namespace PieLang.Compilation.Analysis.Tests
{
    [TestClass]
    public class DefaultAnalysisTests
    {
        [TestMethod]
        public void A_class_is_defined_using_with_syntax()
        {
            var code = Resources.HelloWorld.Split(new [] {Environment.NewLine}, StringSplitOptions.None).First();
            var result = Default.Analysis(code);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(r => r is Keyword));
            Assert.AreEqual(1, result.Count(r => r is Identitifer));
        }

        [TestMethod]
        public void Hello_world_is_correctly_parsed()
        {
            var code = Resources.HelloWorld;
            var result = Default.Analysis(code);
            Assert.AreEqual(7, result.Count());

            Assert.AreEqual(3, result.Count(r => r is Keyword));
            Assert.AreEqual(2, result.Count(r => r is Identitifer));
            Assert.AreEqual(1, result.Count(r=> r is Symbol));
            Assert.AreEqual(1, result.Count(r=> r is StringConstant));
        }
    }
}
