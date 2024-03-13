using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.View;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public static class CommandFacade
{
    private static FilesystemContext _filesystemContext = new FilesystemContext();
    private static Dictionary<string, Action<string[]>> _commandList =
        new Dictionary<string, Action<string[]>>()
        {
            { "connect", Connect },
            { "disconnect", Disconnect },
            { "tree", Tree },
            { "file", File },
            { "help", Help },
            { "exit", Exit },
        };

    public static bool Contains(string command)
    {
        bool contains = _commandList.ContainsKey(command);
        LogFactory.Get().Info($"CommandList.Contains({command}) = {contains}");
        return contains;
    }

    public static Action<string[]> GetAction(string command)
    {
        Action<string[]>? action;
        _commandList.TryGetValue(command, out action);
        if (action != null)
        {
            LogFactory.Get().Info($"CommandList.GetAction({command}) = {action.Method.Name}");
        }
        else
        {
            LogFactory.Get().Info($"CommandList.GetAction({command}) = null");
            throw new InvalidOperationException("action is null");
        }

        return action;
    }

    private static string Arguments(string[] arguments)
    {
        return "[" + string.Join(',', arguments) + "]";
    }

    private static void Connect(string[] arguments)
    {
        LogFactory.Get().Info($"CommandList.Connect({Arguments(arguments)})");
        if (arguments.Length < 3) // [Path] [-m local] -> ["Path", "-m", "local"] - 3! параметра
            throw new ArgumentException("У команды connect должно быть 2 обязательных параметра");
        _filesystemContext.Connect(arguments);
    }

    private static void Disconnect(string[] arguments)
    {
        LogFactory.Get().Info($"CommandList.Disconnect({Arguments(arguments)})");
        if (arguments.Length != 0)
            throw new ArgumentException("У команды disconnect не должно быть параметров");
        _filesystemContext.Disconnect(arguments);
    }

    private static void Tree(string[] arguments)
    {
        LogFactory.Get().Info($"CommandList.Tree({Arguments(arguments)})");
        if (arguments.Length < 1)
            throw new ArgumentException("У команды tree должна быть операция и можеть быть еще 1 параметр");
        switch (arguments[0])
        {
            case "goto":
                _filesystemContext.GotoTree(arguments);
                break;
            case "list":
                _filesystemContext.ListTree(arguments);
                break;
            default:
                string ops = "[goto|list]";
                throw new ArgumentException($"У команды tree допускаются только операции {ops}");
        }
    }

    private static void File(string[] arguments)
    {
        LogFactory.Get().Info($"CommandList.File({Arguments(arguments)})");
        if (arguments.Length < 2)
            throw new ArgumentException("У команды file должна быть операция и не менее 1 параметра");
        switch (arguments[0])
        {
            case "show":
                _filesystemContext.ShowFile(arguments);
                break;
            case "move":
                _filesystemContext.MoveFile(arguments);
                break;
            case "copy":
                _filesystemContext.CopyFile(arguments);
                break;
            case "delete":
                _filesystemContext.DeleteFile(arguments);
                break;
            case "rename":
                _filesystemContext.RenameFile(arguments);
                break;
            default:
                string ops = "[show|move|copy|delete|rename]";
                throw new ArgumentException($"Для команды file допускаются только операции {ops}");
        }
    }

    private static void Help(string[] arguments)
    {
        LogFactory.Get().Info($"CommandList.Help({Arguments(arguments)})");
        Display.Help();
    }

    private static void Exit(string[] arguments)
    {
        LogFactory.Get().Info($"CommandList.Exit({Arguments(arguments)})");
        Display.Exit();
        Environment.Exit(0);
    }
}