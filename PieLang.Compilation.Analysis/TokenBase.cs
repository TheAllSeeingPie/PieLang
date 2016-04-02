namespace PieLang.Compilation.Analysis
{
    public class TokenBase : IToken
    {
        public TokenBase(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}