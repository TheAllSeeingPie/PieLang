using System.Collections.Generic;
using PieLang.Compilation.Analysis.Tokens;

namespace PieLang.Compilation.Parsing
{
    public class Default
    {
        public static void Parse(IEnumerable<IToken> tokens)
        {
            var parser = new TokenParser(tokens);

            parser.Parse();
        }
    }
}
