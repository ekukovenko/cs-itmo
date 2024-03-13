using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

public class ConsoleLogger : Logger
{
    public ConsoleLogger(CultureInfo cultureInfo)
        : base(cultureInfo) { }
    protected override void Log(string level, string text)
    {
        Console.WriteLine($"{GetNowDateTime()} {level,-7} - {text}");
    }
}