using System;
using System.Globalization;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.View;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public class FilesystemConnected : FilesystemState
{
    private static CultureInfo _cultureInfo = new CultureInfo("ru-RU");
    public override void Execute(FilesystemCommand command, string[] arguments, FilesystemContext context)
    {
        ArgumentNullException.ThrowIfNull(arguments);
        ArgumentNullException.ThrowIfNull(context);
        switch (command)
        {
            case FilesystemCommand.Disconnect:
                Disonnect(arguments, context);
                break;
            case FilesystemCommand.GotoTree:
                GotoTree(arguments, context);
                break;
            case FilesystemCommand.ListTree:
                ListTree(arguments, context);
                break;
            case FilesystemCommand.ShowFile:
                ShowFile(arguments, context);
                break;
            case FilesystemCommand.MoveFile:
                MoveFile(arguments, context);
                break;
            case FilesystemCommand.CopyFile:
                CopyFile(arguments, context);
                break;
            case FilesystemCommand.DeleteFile:
                DeleteFile(arguments, context);
                break;
            case FilesystemCommand.RenameFile:
                RenameFile(arguments, context);
                break;
            default:
                throw new NotSupportedException($"Команда {command} не поддерживается для FilesystemConnected");
        }
    }

    private static void GotoTree(string[] arguments, FilesystemContext context)
    {
        if (arguments.Length != 2) throw new ArgumentException("Отсутствует параметр для команды tree goto");
        string path = arguments[1];
        if (path[0] != Path.DirectorySeparatorChar) path = context.AbsDir + path;
        if (!PathExists(path)) throw new ArgumentException($"Каталог {path} не существует");

        context.AbsDir = path;
        Display.Write($"Навигация по дереву файловой системы в каталог {path}");
    }

    private static void ListTree(string[] arguments, FilesystemContext context)
    {
        if (!(arguments.Length == 1 || arguments.Length == 3)) throw new ArgumentException("Отсутствуют параметры для команды tree list");
        string path = context.AbsDir;
        if (!PathExists(path)) throw new ArgumentException($"Каталог {path} не существует");
        if (arguments.Length == 3 && arguments[1] != "-d") throw new ArgumentException("Отсутствует параметр глубины выборки");
        int depth = (arguments.Length == 3) ? Convert.ToInt32(arguments[2], _cultureInfo) : -1;

        TreeItem treeItem = TreeBuilder.Build(path, depth);
        Display.WriteTreeItem($"Просмотр содержимого каталога {path} глубиной {depth}", treeItem);
    }

    private static void ShowFile(string[] arguments, FilesystemContext context)
    {
        if (!(arguments.Length == 2 || arguments.Length == 4)) throw new ArgumentException("Отсутствуют параметры для команды file show");
        string sourceFile = (arguments[1][0] == Path.DirectorySeparatorChar) ? arguments[1] : context.AbsDir + arguments[1];
        if (!FileExists(sourceFile)) throw new ArgumentException($"Файл {sourceFile} не существует");
        if (arguments.Length == 4 && arguments[2] != "-m") throw new ArgumentException("Отсутствует параметр для режима вывода");
        if (arguments.Length == 4 && arguments[3] != "console") throw new ArgumentException("Поддерживается режим вывода только console");

        Display.WriteFileContent($"Просмотр содержимого файла {sourceFile} в консоли", sourceFile);
    }

    private static void MoveFile(string[] arguments, FilesystemContext context)
    {
        if (arguments.Length != 3) throw new ArgumentException("Отсутствуют параметры для команды file move");
        string sourceFile = arguments[1][0] == Path.DirectorySeparatorChar ? arguments[1] : context.AbsDir + arguments[1];
        if (!FileExists(sourceFile)) throw new ArgumentException($"Файл {sourceFile} не существует");
        string destPath = arguments[2];
        if (destPath[0] != Path.DirectorySeparatorChar) destPath = context.AbsDir + destPath;
        if (destPath[destPath.Length - 1] != Path.DirectorySeparatorChar) destPath += Path.DirectorySeparatorChar;
        if (!PathExists(destPath)) throw new ArgumentException($"Каталог {destPath} не существует");
        string destFile = destPath + arguments[1];
        if (PathExists(destFile)) throw new ArgumentException($"Файл {destFile} уже существует");

        File.Move(sourceFile, destFile);
        Display.Write($"Перемещение файла {sourceFile} в каталог {destPath}");
    }

    private static void CopyFile(string[] arguments, FilesystemContext context)
    {
        if (arguments.Length != 3) throw new ArgumentException("Отсутствуют параметры для команды file copy");
        string sourceFile = (arguments[1][0] == Path.DirectorySeparatorChar) ? arguments[1] : context.AbsDir + arguments[1];
        if (!FileExists(sourceFile)) throw new ArgumentException($"Файл {sourceFile} не существует");
        string destPath = arguments[2];
        if (destPath[0] != Path.DirectorySeparatorChar) destPath = context.AbsDir + destPath;
        if (destPath[destPath.Length - 1] != Path.DirectorySeparatorChar) destPath += Path.DirectorySeparatorChar;
        if (!PathExists(destPath)) throw new ArgumentException($"Каталог {destPath} не существует");
        string destFile = destPath + arguments[1];
        if (PathExists(destFile)) throw new ArgumentException($"Файл {destFile} уже существует");

        File.Copy(sourceFile, destFile);
        Display.Write($"Копирование файла {sourceFile} в каталог {destPath}");
    }

    private static void DeleteFile(string[] arguments, FilesystemContext context)
    {
        if (arguments.Length != 2) throw new ArgumentException("Отсутствуют параметры для команды file delete");
        string sourceFile = arguments[1][0] == Path.DirectorySeparatorChar ? arguments[1] : context.AbsDir + arguments[1];
        if (!FileExists(sourceFile)) throw new ArgumentException($"Файл {sourceFile} не существует");

        File.Delete(sourceFile);
        Display.Write($"Удвление файла {sourceFile}");
    }

    private static void RenameFile(string[] arguments, FilesystemContext context)
    {
        if (arguments.Length != 3) throw new ArgumentException("Отсутствуют параметры для команды file rename");
        string sourceFile = (arguments[1][0] == Path.DirectorySeparatorChar) ? arguments[1] : context.AbsDir + arguments[1];
        if (!FileExists(sourceFile)) throw new ArgumentException($"Файл {sourceFile} не существует");
        string destFile = arguments[2][0] == Path.DirectorySeparatorChar ? arguments[2] : context.AbsDir + arguments[2];
        if (FileExists(destFile)) throw new ArgumentException($"Файл {destFile} уже существует");

        File.Move(sourceFile, destFile);
        Display.Write($"Переименование файла {sourceFile} в {destFile}");
    }

    private static void Disonnect(string[] arguments, FilesystemContext context)
    {
        if (arguments.Length != 0) throw new ArgumentException($"Должны отсутствовать параметры у команды disconnect вместо {arguments}");
        context.State = new FilesystemDisconnected();
        context.AbsDir = string.Empty;
        context.RelDir = string.Empty;
        Display.Write($"Отключение от файловой системы");
    }
}