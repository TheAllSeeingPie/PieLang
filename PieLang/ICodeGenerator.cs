using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieLang
{
    public interface ICodeGenerator
    {
        void BeginClass(string name);
    }
}
