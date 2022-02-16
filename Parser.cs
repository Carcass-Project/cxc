using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoakke;
using Yoakke.SynKit.Parser;
using Yoakke.SynKit.Parser.Attributes;
using Yoakke.SynKit.C.Syntax;
using cxc.Components;
using cxc.Components.Expressions;
using cxc.Components.Statements;
using Token = Yoakke.SynKit.Lexer.IToken<Yoakke.SynKit.C.Syntax.CTokenType>;

namespace cxc
{
    [Parser(typeof(CTokenType))]
    public partial class Parser
    {
        [Rule("program: stmt*")]
        private static IReadOnlyList<Statement> Program(IReadOnlyList<Statement> stmtList)
        {
            return stmtList;
        }

        [Rule("block_stmt: '{' stmt* '}'")]
        private static BlockStatement blockStatementRule(Token _1, IReadOnlyList<Statement> statements, Token _2)
        {
            return new BlockStatement(statements);
        }

        [Rule("stmt: type_identifier Identifier '(' (type_identifier Identifier (',' type_identifier Identifier)*)? ')' block_stmt ")]
        private static Statement functionIntDeclaration(Token type, Token Identifier, Punctuated<Token, Token> paramList, Token _1B, Token _2B, BlockStatement fnBody)
        {
            return new FnDeclStatement(type, Identifier , fnBody);
        }

        [Rule("type_identifier: (KeywordInt|KeywordVoid|KeywordChar|KeywordDouble|KeywordFloat|KeywordLong|KeywordShort|KeywordBool|KeywordComplex)")]
        private static Token typeident(Token ident)
        {
            return ident;
        }

        [Rule("stmt: KeywordReturn expression ';' ")]
        private static Statement returnStatement(Token _1, Expression expr, Token _semi)
        {
            return new ReturnStatement(expr);
        }

        [Rule("expression : IntLiteral")]
        public static Expression IntLiteral(Token token) { return new IntLiteral(token.Text); }
    }
}
