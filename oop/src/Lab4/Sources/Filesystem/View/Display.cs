using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.View;

public static class Display
{
    private const string ShellPrompt = "\n$ ";

    public static void Prompt()
    {
        Console.Write($"{ShellPrompt}");
    }

    public static void Exit()
    {
        LogFactory.Get().Info($"Display.Exit()");
        Console.WriteLine("Завершение работы");
    }

    public static void Write(string text)
    {
        LogFactory.Get().Info($"Display.Write({text})");
        Console.WriteLine(text);
    }

    public static void WriteTreeItem(string text, TreeItem tree)
    {
        ArgumentNullException.ThrowIfNull(tree);
        LogFactory.Get().Info($"Display.WriteTreeItem({text})");

        Console.WriteLine(text);
        TextWriter streamWriter = Console.Out;
        tree.WriteTree(streamWriter);
    }

    public static void WriteFileContent(string text, string file)
    {
        LogFactory.Get().Info($"Display.WriteFileContent({text})");

        Console.WriteLine(text);
        TextWriter streamWriter = Console.Out;
        var textFile = new TextFile(file);
        textFile.WriteContent(streamWriter);
    }

    public static void Help()
    {
        LogFactory.Get().Info($"Display.Help()");
        const string help =
            "$ connect [Address] [-m Mode]\n" +
            "  Address - абсолютный путь в подключаемой файловой системе\n" +
            "  Mode - режим файловой системы (только локальная ФС – значение `local`)\n" +
            "$ disconnect\n" +
            "  Отключается от файловой системы\n" +
            "$ tree goto [Path]\n" +
            "  Path - относительный или абсолютный путь до каталога в файловой системе\n" +
            "$ tree list {-d Depth}\n" +
            "  Depth - параметр, определяющий глубину выборки, должен объявляться флагом `-d`\n" +
            "$ file show [Path] {-m Mode}\n" +
            "  Path - относительный или абсолютный путь до файла\n" +
            "  Mode - режим вывода файла (требуется реализовать только консольный, значение `console`)\n" +
            "$ file move [SourcePath] [DestinationPath]\n" +
            "  SourcePath - относительный или абсолютный путь до перемещаемого файла\n" +
            "  DestinationPath - относительный или абсолютный  путь до директории, куда файл должен быть перемещён\n" +
            "$ file copy [SourcePath] [DestinationPath]\n" +
            "  SourcePath - относительный или абсолютный путь до копируемого файла\n" +
            "  DestinationPath - относительный или абсолютный путь до директории, куда файл должен быть скопирован\n" +
            "$ file delete [Path]\n" +
            "  Path - относительный или абсолютный путь до удаляемого файла\n" +
            "$ file rename [Path] [Name]\n" +
            "  Path - относительный или абсолютный путь до изменяемого файла\n" +
            "  Name - новое имя файла";
        Console.WriteLine(help);
    }

    public static void UnknownCommand(string command)
    {
        LogFactory.Get().Warning($"Display.UnknownCommand({command})");
        Console.WriteLine("Неизвестная команда: для помощи введите help, для выхода – exit");
    }

    public static void Error(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        LogFactory.Get().Error($"{text}");
        Console.WriteLine($"Ошибка: {text}");
    }

    public static void Exception(Exception e)
    {
        ArgumentNullException.ThrowIfNull(e);
        LogFactory.Get().Warning($"Display.Exception({e.GetType().Name}: {e.Message})");
        Console.WriteLine($"Исключение {e.GetType().Name}: {e.Message}, обратитесь к help");
    }
}