using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PieLang.Compilation.Analysis.Tests
{
    [TestClass]
    public class DefaultAnalysisTests
    {
        [TestMethod]
        public void A_class_is_defined_using_with_syntax()
        {
            var code = "with HelloWorld";
            var result = Default.Analyse(code);
            Assert.AreEqual(2, result.Count());
        }
    }
}
