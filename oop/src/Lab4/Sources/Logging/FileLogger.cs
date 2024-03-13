using System;
using System.Globalization;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

public class FileLogger : Logger
{
    public FileLogger(CultureInfo cultureInfo)
        : base(cultureInfo) { }
    private static string FilePath { get; } = $"{Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0])}.log";
    protected override void Log(string level, string text)
    {
        File.AppendAllText(FilePath, $"{GetNowDateTime()} {level,-7} - {text}\n");
    }
}