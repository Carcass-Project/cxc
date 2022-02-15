using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cxc.Binder.BoundNodes;
using cxc.Binder.BoundNodes.BoundExpressions;

namespace cxc.Emitter
{
    public class Emitter
    {
        public AssemblyEmitter emitter = new AssemblyEmitter();

        public object Visit(BoundExpression expr) => expr switch
        {
            BoundIntLiteral => this.Visit(expr as BoundIntLiteral),
            _ => throw new Exception("Unknown expression "+expr)
        };
        
        public object Visit(BoundIntLiteral expr)
        {
            return expr.Value;
        }

        public void Emit(List<BoundNode> nodes)
        {
            foreach (BoundNode node in nodes)
            {
                switch(node)
                {
                    case BoundFunctionNode:
                        var fnnode = node as BoundFunctionNode;
                        emitter.Emit(AssemblyInstruction.GLOBAL, fnnode.Name);
                        emitter.Emit(AssemblyInstruction.LABEL, fnnode.Name);
                        Emit(fnnode.body.body);
                        emitter.Emit(AssemblyInstruction.RET);
                        break;
                    case BoundBlockNode:
                        var blocknode = node as BoundBlockNode;
                        Emit(blocknode.body);
                        break;
                    case BoundReturnNode:
                        var returnnode = node as BoundReturnNode;
                        emitter.Emit(AssemblyInstruction.MOV, Visit(returnnode.Expression), "eax");
                        break;

                    default:
                        throw new Exception("Unknown Node/Statement Used.");
                }
            }
        }
    }
}
