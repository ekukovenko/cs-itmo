using System;
using System.Globalization;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class FileLogger : Logger
{
    private string FilePath { get; } = $"{Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0])}.log";

    protected override void Log(string type, string text)
    {
        var culture = CultureInfo.GetCultureInfo("ru-RU");
        string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", culture);
        File.AppendAllText(FilePath, $"{now} {type,-7} - {text}\n");
    }
}