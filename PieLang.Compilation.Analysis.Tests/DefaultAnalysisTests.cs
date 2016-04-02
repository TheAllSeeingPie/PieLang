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
            var code = "with HelloWorld as";
            var result = Default.Analyse(code);
            Assert.AreEqual(3, result.Count());
        }
    }
}
