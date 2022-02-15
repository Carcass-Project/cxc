using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cxc.Components;
using cxc.Components.Statements;
using cxc.Components.Expressions;
using cxc.SymbolicResolution;
using cxc.SymbolicResolution.Symbols;
using cxc.Binder.BoundNodes;
using cxc.Binder.BoundNodes.BoundExpressions;

namespace cxc.Binder
{
    public enum BasicTypes
    {
        Int,
        Char,
        Float,
        Void,
        UInt
    }

    public class Binder
    {
        public List<Scope> Scopes = new List<Scope>();
        public Scope? currentScope;

        internal BasicTypes? DecideType(string text)
        {
            switch (text)
            {
                case "int":
                    return BasicTypes.Int;
                case "char":
                    return BasicTypes.Char;
                case "float":
                    return BasicTypes.Float;
                case "void":
                    return BasicTypes.Void;
            }
            return null;
        }

        public BoundExpression? BindExpression(Expression expr)
        {
            switch(expr)
            {
                case IntLiteral:
                    var boundIntLiteral = new BoundIntLiteral();
                    boundIntLiteral.Value = int.Parse((expr as IntLiteral).Value);
                    return boundIntLiteral;
                default:
                    Console.WriteLine("Couldn't bind this expression, as it is unknown.");
                    return null;
            }
            return null;
        }

        public BoundNode? BindNode(Statement x)
        {
            switch (x.kind)
            {
                case StatementKind.FUNC_DECL:
                    var fnstmt = x as FnDeclStatement;
                    var boundfnstmt = new BoundFunctionNode();
                    boundfnstmt.Name = fnstmt.name.Text;
                    boundfnstmt.body = (BoundBlockNode)BindNode(fnstmt.body);
                    var type = DecideType(fnstmt.type.Text);
                    if (type == null)
                        Console.WriteLine("Could not decide function return type.");
                    var sc = new Scope();
                    sc.parent = currentScope;
                    currentScope = sc;
                    var symb = new FunctionSymbol();
                    symb.name = boundfnstmt.Name;
                    currentScope.symbols.Add(boundfnstmt.Name, symb);
                    return boundfnstmt;
                case StatementKind.BLOCK:
                    var blockstmt = x as BlockStatement;
                    var boundone = new BoundBlockNode();
                    foreach(var s in blockstmt._statements)
                    {
                        boundone.body.Add(BindNode(s));
                    }
                    return boundone;
                case StatementKind.RETURN:
                    var returnstmt = x as ReturnStatement;
                    var boundRet = new BoundReturnNode();
                    boundRet.Expression = BindExpression(returnstmt.what);

                    return boundRet;
            }
            return null;
        }

        public List<BoundNode> BindNodes(IReadOnlyList<Statement> stmts)
        {
            var nodes = new List<BoundNode>();

            foreach (var x in stmts)
            {
               nodes.Add(BindNode(x));   
            }

            return nodes;
        }
    }
}
