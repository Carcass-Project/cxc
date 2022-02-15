using Yoakke;
using Yoakke.SynKit.Parser;
using Yoakke.SynKit.C.Syntax;
using cxc;
using cxc.Components.Statements;



void ReadFile(string path)
{
    var lexer = new CLexer(File.ReadAllText(path));
    var pp = new CPreProcessor(lexer);
    var parser = new Parser(lexer);
    var program = parser.ParseProgram();

    if(program.IsOk)
    {
        foreach(var x in program.Ok.Value)
        {
            Console.WriteLine(x);
            foreach(var f in (x as FnDeclStatement).body._statements)
            {
                Console.WriteLine(f);
            }
        }
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