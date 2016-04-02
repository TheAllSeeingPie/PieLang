using System.Collections.Generic;
using PieLang.Compilation.Analysis.Tokens;

namespace PieLang.Compilation.Analysis
{
    public class Default
    {
        public static IEnumerable<IToken> Analysis(string code)
        {
            var analyser = new LexicalAnalyser(code);

            return analyser.Analyse();
        }
    }
}