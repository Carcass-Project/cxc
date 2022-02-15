using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc.Components.Expressions
{
    public class IntLiteral : Expression
    {
        public string Value { get; set; }

        public IntLiteral(string value)
        {
            Value = value;
        }
    }
}
