namespace PieLang.Compilation.Analysis
{
    public interface IToken
    {
        string Value { get; }
    }

    public class TokenBase : IToken
    {
        public TokenBase(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }

    public class Keyword : TokenBase
    {
        public Keyword(string value) : base(value)
        {
        }
    }

    public class Identitifer : TokenBase
    {
        public Identitifer(string value) : base(value)
        {
        }
    }
}
