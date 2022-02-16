using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoakke.SynKit.Lexer;
using Yoakke.SynKit.C.Syntax;
using Yoakke.Collections.Values;
using Yoakke.SynKit.Parser;

namespace cxc.Components.Statements
{
    public class FnDeclStatement : Statement
    {
      
        public IToken<CTokenType> type;
        public IToken<CTokenType> name;
        public Punctuated<IToken<CTokenType>, IToken<CTokenType>> paramsList;
        public BlockStatement body;

        public FnDeclStatement(IToken<CTokenType> type, IToken<CTokenType> name, Punctuated<IToken<CTokenType>, IToken<CTokenType>> _paramsList, BlockStatement body)
        {
            kind = StatementKind.FUNC_DECL;
            this.paramsList = _paramsList;
            this.type = type;
            this.name = name;
            this.body = body;
        }
    }
}
