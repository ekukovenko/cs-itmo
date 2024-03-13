using System;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.View;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public class FilesystemDisconnected : FilesystemState
{
    public override void Execute(FilesystemCommand command, string[] arguments, FilesystemContext context)
    {
        ArgumentNullException.ThrowIfNull(arguments);
        ArgumentNullException.ThrowIfNull(context);
        switch (command)
        {
            case FilesystemCommand.Connect:
                Connect(arguments, context);
                break;
            default:
                throw new NotSupportedException($"Команда {command} не поддерживается для FilesystemDisconnected");
        }
    }

    private static void Connect(string[] arguments, FilesystemContext context)
    {
        if (arguments.Length != 3) throw new ArgumentException("Отсутствует часть параметров для команды connect");
        if (!PathExists(arguments[0])) throw new ArgumentException($"Путь {arguments[0]} не существует");
        if (arguments[1] != "-m") throw new ArgumentException("Отсутствует параметр режима для команды connect");
        if (arguments[2] != "local") throw new ArgumentException("Поддерживается только файловая система local");

        context.State = new FilesystemConnected();
        context.AbsDir = arguments[0];
        Display.Write($"Подключение к локальной файловой системе в {context.AbsDir}");
    }
}