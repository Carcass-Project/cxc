using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoakke.Collections.Values;

namespace cxc.Components.Statements
{
    public class BlockStatement : Statement
    {
        
        public IReadOnlyList<Statement> _statements;

        public BlockStatement(IReadOnlyList<Statement> statements)
        {
            kind = StatementKind.BLOCK;
            _statements = statements;
        }
    }
}
