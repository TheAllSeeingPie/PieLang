using System;
using System.Collections.Generic;
using System.Linq;
using PieLang.Compilation.Analysis.Tokens;

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

            if (Syntax.IsSymbol(CurrentChar()))
            {
                var token = FetchStringWhile(c => !char.IsWhiteSpace(CurrentChar()));
                _tokens.Add(new Symbol(token));
            }

            if (Syntax.IsStringConstantIdentifier(CurrentChar()))
            {
                CurrentPosition++;
                var token = FetchStringWhile(c => !Syntax.IsStringConstantIdentifier(c));
                _tokens.Add(new StringConstant(token));
            }

            if (Syntax.IsStartOfKeywordOrIdentifier(@char))
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
            while (CurrentPosition < _data.Length && shouldContinue(CurrentChar()))
            {
                chars.Add(CurrentChar());
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