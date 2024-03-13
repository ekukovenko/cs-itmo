using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Controller;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public class Program
{
    private readonly string[] _args;

    public Program(string[] args)
    {
        _args = args;
    }

    public static void Main(string[] args)
    {
        var app = new Program(args);
        app.Run();
    }

    private void Run()
    {
        Logger logger = (_args.Length > 0 && _args[0] == "--verbose") ?
            new ConsoleLogFactory().Create() :
            new FileLogFactory().Create();

        string arguments = string.Join(',', _args);
        logger.Info($"start with args:[{arguments}]");

        var shell = new Shell();
        shell.Run();

        logger.Info("stop");
    }
}
