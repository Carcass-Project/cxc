using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc.Components.Statements
{
    public class ReturnStatement : Statement
    {
        public StatementKind Kind = StatementKind.RETURN;
        public Expression what;

        public ReturnStatement(Expression wht)
        {
            what = wht;
        }
    }
}
