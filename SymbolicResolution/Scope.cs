using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc.SymbolicResolution
{
    public class Scope
    {
        Scope? parent;
        Dictionary<string, Symbol> symbols = new Dictionary<string, Symbol>();

        public Symbol? Lookup(string name)
        {
            if (symbols.ContainsKey(name))
                return symbols[name];

            if (parent != null)
                return parent.Lookup(name);

            return null;
        }
    }
}
