using System;
using System.Collections.Generic;
using System.Linq;

namespace PieLang.Compilation.Analysis
{
    public class LexicalAnalyser
    {
        private readonly char[] _data;
        private int CurrentPosition;
        private IList<IToken> _tokens = new List<IToken>();

        public LexicalAnalyser(string data)
        {
            _data = data.ToArray();
        }

        public bool IsComplete { get; private set; }

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
            var @char = CurrentChar();

            if (Syntax.IsStartOfKeywordOrIdentifier(@char))
            {
                var token = ContinueWhile(Syntax.IsPartOfKeywordOrIdentitifer);
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

        private string ContinueWhile(Func<char, bool> shouldContinue)
        {
            var chars = new List<char> {CurrentChar()};
            while (CurrentPosition < _data.Length && shouldContinue(CurrentChar()))
            {
                CurrentPosition++;
            }
            return new string(chars.ToArray());
        }

        private char CurrentChar()
        {
            return _data[CurrentPosition];
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