using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc.SymbolicResolution.Symbols
{
    public class FunctionSymbol : Symbol
    {
        IReadOnlyList<ParameterSymbol>? parameters;
    }
}
