using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Construction
{
    public class token
    {
        public token(ushort line, string word)
        {
            lineNumber = line;
            wordString = word;
        }
        public token(ushort line, string word, string classs)
        {
            lineNumber = line;
            wordString = word;
            classString = classs;
        }
        public ushort lineNumber = 1;
        public string wordString;
        public string classString;
    }
}
