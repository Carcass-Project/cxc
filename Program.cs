using Yoakke;
using Yoakke.SynKit.Parser;
using Yoakke.SynKit.C.Syntax;
using cxc;
using cxc.Binder;
using cxc.Binder.BoundNodes;
using cxc.Components.Statements;

void RecursiveWrite(List<BoundNode> nodes)
{
    foreach(BoundNode node in nodes)
    {
        Console.WriteLine(node);
        foreach(BoundNode node2 in (node as BoundFunctionNode).body.body)
        {
            Console.WriteLine(node2);
        }
    }
}

void ReadFile(string path)
{
    var lexer = new CLexer(File.ReadAllText(path));
    var pp = new CPreProcessor(lexer);
    var parser = new Parser(lexer);
    var program = parser.ParseProgram();

    if(program.IsOk)
    {
        var binder = new Binder();
        var nodes = binder.BindNodes(program.Ok.Value);
        var emitter = new cxc.Emitter.Emitter();
        emitter.Emit(nodes);
        Console.WriteLine(emitter.emitter.GrabAssembly());
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Something went wrong while parsing your C program");
        Console.WriteLine("Got: " + program.Error.Got.ToString() + " at Position " + program.Error.Position);
        Console.ResetColor();
    }
}


ReadFile("inttest.c");

// Basic Return 2 Code:

/*cxc.Emitter em = new cxc.Emitter();
em.Emit(cxc.AssemblyInstruction.GLOBAL, "main");
em.Emit(cxc.AssemblyInstruction.LABEL, "main");
em.Emit(cxc.AssemblyInstruction.MOV, 2, "eax");
em.Emit(cxc.AssemblyInstruction.RET);

Console.WriteLine("Generated Assembly:\n" + em.GrabAssembly());*/