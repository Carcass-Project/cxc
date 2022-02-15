using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc.Binder.BoundNodes
{
    public class BoundReturnNode : BoundNode
    {
        public BoundExpressions.BoundExpression? Expression { get; set; }
    }
}
