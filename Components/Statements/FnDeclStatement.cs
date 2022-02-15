using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoakke.SynKit.Lexer;
using Yoakke.SynKit.C.Syntax;

namespace cxc.Components.Statements
{
    public class FnDeclStatement : Statement
    {
        public StatementKind Kind = StatementKind.FUNC_DECL;
        public IToken<CTokenType> type;
        public IToken<CTokenType> name;
        public BlockStatement body;

        public FnDeclStatement(IToken<CTokenType> type, IToken<CTokenType> name, BlockStatement body)
        {
            this.type = type;
            this.name = name;
            this.body = body;
        }
    }
}
