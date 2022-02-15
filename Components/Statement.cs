using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc.Components
{
    public enum StatementKind
    {
        FUNC_DECL,
        BLOCK,
        RETURN
    }
    public class Statement
    {
        public StatementKind kind { get; set; }
    }
}
