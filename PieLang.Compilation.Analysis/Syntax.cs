using System.Collections.Generic;
using System.Linq;

namespace PieLang.Compilation.Analysis
{
    public class Syntax
    {
        private static string[] _keywords = { "with", "as", "define" };
        private static string[] _symbols = {">", "->"};

        public static bool IsKeyword(string value)
        {
            return _keywords.Contains(value);
        }

        public static bool IsPartOfKeywordOrIdentitifer(char c)
        {
            return char.IsLetter(c);
        }

        public static bool IsStartOfKeywordOrIdentifier(char c)
        {
            return char.IsLetter(c);
        }

        public static bool IsStringConstantIdentifier(char c)
        {
            return c == '"';
        }

        public static bool IsSymbol(char c)
        {
            return _symbols.Select(s => s.First()).Contains(c);
        }
    }
}