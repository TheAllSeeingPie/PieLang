namespace PieLang.Compilation.Analysis
{
    public class Syntax
    {
        public static bool IsKeyword(string value)
        {
            return value == "with";
        }

        public static bool IsPartOfKeywordOrIdentitifer(char c)
        {
            return char.IsLetter(c);
        }

        public static bool IsStartOfKeywordOrIdentifier(char c)
        {
            return char.IsLetter(c);
        }
    }
}