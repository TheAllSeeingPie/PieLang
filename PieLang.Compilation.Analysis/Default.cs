using System.Collections.Generic;

namespace PieLang.Compilation.Analysis
{
    public class Default
    {
        public static IEnumerable<IToken> Analyse(string code)
        {
            var analyser = new LexicalAnalyser(code);

            return analyser.Analyse();
        }
    }
}