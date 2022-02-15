using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc.Components.Statements
{
    public class ReturnStatement : Statement
    {
       
        public Expression what;

        public ReturnStatement(Expression wht)
        {
            kind = StatementKind.RETURN;
            what = wht;
        }
    }
}
