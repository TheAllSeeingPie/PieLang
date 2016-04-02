using System;
using System.Collections.Generic;
using System.Linq;
using PieLang.Compilation.Analysis.Tokens;

namespace PieLang.Compilation.Analysis
{
    public class LexicalAnalyser : GenericIterator<char>
    {
        private IList<IToken> _tokens = new List<IToken>();

        public LexicalAnalyser(string data) : base (data.ToArray())
        {
        }

        public IEnumerable<IToken> Analyse()
        {
            while (!IsComplete)
            {
                Advance();
                CurrentPosition++;
            }
            return _tokens;
        }

        private void Advance()
        {
            if (CurrentPosition >= _data.Length)
            {
                IsComplete = true;
                return;
            }

            IgnoreWhitespace();
            var @char = Current();

            if (Syntax.IsSymbol(Current()))
            {
                var token = FetchStringWhile(c => !char.IsWhiteSpace(Current()));
                _tokens.Add(new Symbol(token));
            } else if (Syntax.IsStringConstantIdentifier(Current()))
            {
                CurrentPosition++;
                var token = FetchStringWhile(c => !Syntax.IsStringConstantIdentifier(c));
                _tokens.Add(new StringConstant(token));
            } else if (Syntax.IsStartOfKeywordOrIdentifier(@char))
            {
                var token = FetchStringWhile(Syntax.IsPartOfKeywordOrIdentitifer);
                if (Syntax.IsKeyword(token))
                {
                    _tokens.Add(new Keyword(token));
                }
                else
                {
                    _tokens.Add(new Identitifer(token));
                }
            }
        }

        private string FetchStringWhile(Func<char, bool> shouldContinue)
        {
            var chars = new List<char>();
            while (CurrentPosition < _data.Length && shouldContinue(Current()))
            {
                chars.Add(Current());
                CurrentPosition++;
            }
            return new string(chars.ToArray());
        }

        private void IgnoreWhitespace()
        {
            var @char = _data[CurrentPosition];
            while (char.IsWhiteSpace(@char))
            {
                CurrentPosition++;
                @char = _data[CurrentPosition];
            }
        }
    }
}