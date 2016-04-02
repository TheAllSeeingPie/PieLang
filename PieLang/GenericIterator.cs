using System.Collections.Generic;
using System.Linq;

namespace PieLang
{
    public class GenericIterator<T>
    {
        protected readonly T[] _data;
        protected int CurrentPosition;

        public GenericIterator(IEnumerable<T> tokens)
        {
            _data = tokens.ToArray();
        }

        public bool IsComplete { get; protected set; }

        protected T Current()
        {
            return _data[CurrentPosition];
        }

        protected T LookAhead()
        {
            return _data[CurrentPosition + 1];
        }

        protected T LookBehind()
        {
            return _data[CurrentPosition - 1];
        }
    }
}
