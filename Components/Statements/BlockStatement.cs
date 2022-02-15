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
        public StatementKind kind = StatementKind.BLOCK;
        public IReadOnlyList<Statement> _statements;

        public BlockStatement(IReadOnlyList<Statement> statements)
        {
            _statements = statements;
        }
    }
}
