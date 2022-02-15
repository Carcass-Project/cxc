using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cxc
{
    public enum AssemblyInstruction
    {
        MOV,
        LABEL,
        RET,
        GLOBAL
    }

    public class AssemblyEmitter
    {
        StringBuilder sb = new StringBuilder();

        public void Emit(AssemblyInstruction ins, params object[] objs)
        {
            switch (ins)
            {
                case AssemblyInstruction.MOV:
                    sb.AppendLine("mov " + objs[0] + ", " + objs[1]);
                    break;
                case AssemblyInstruction.LABEL:
                    sb.AppendLine(objs[0] + ":");
                    break;
                case AssemblyInstruction.GLOBAL:
                    sb.AppendLine(".global " + objs[0]);
                    break;
                case AssemblyInstruction.RET:
                    sb.AppendLine("ret");
                    break;
            }
        }

        public string GrabAssembly()
        {
            return sb.ToString();
        }
    }
}
