using System.Collections.Generic;
using System.Linq;
using PieLang.Compilation.Analysis.Tokens;

namespace PieLang.Compilation.Parsing
{
    internal class TokenParser : GenericIterator<IToken>
    {
        private ICodeGenerator _codeGenerator;

        public TokenParser(IEnumerable<IToken> tokens) : base (tokens.ToArray())
        {
        }

        public void Parse()
        {
            while (!IsComplete)
            {
                Advance();
                CurrentPosition++;
            }
        }

        private void Advance()
        {
            if (CurrentPosition >= _data.Length)
            {
                IsComplete = true;
                return;
            }

            if (Current() is Keyword)
            {
                var token = Current();
                if (token.Value == "with")
                {
                    CurrentPosition++;
                    _codeGenerator.BeginClass(Current().Value);
                    CurrentPosition++;
                }
            }
        }
    }
}