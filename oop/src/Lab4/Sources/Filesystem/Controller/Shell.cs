using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.View;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Controller;

public class Shell
{
    private readonly Logger _logger;
    private readonly char[] _separator = new char[] { ' ' };

    public Shell()
    {
        _logger = LogFactory.Get();
    }

    public void Run()
    {
        while (true)
        {
            Display.Prompt();
            string? commandLine = Console.ReadLine();
            if (commandLine != null)
            {
                string[] commandItems = commandLine.Split(_separator);
                string command = commandItems[0];
                string[] arguments = commandItems.TakeLast(commandItems.Length - 1).ToArray();
                string args = string.Join(",", arguments);
                _logger.Info($"commandLine: '{commandLine}' -> command:{command} arguments:[{args}]");

                if (CommandFacade.Contains(command))
                {
                    Action<string[]> action = CommandFacade.GetAction(command);
                    action(arguments);
                }
                else
                {
                    Display.UnknownCommand(command);
                }
            }
        }
    }
}