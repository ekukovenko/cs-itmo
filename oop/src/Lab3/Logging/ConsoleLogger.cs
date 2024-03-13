using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class ConsoleLogger : Logger
{
    protected override void Log(string type, string text)
    {
        var culture = CultureInfo.GetCultureInfo("ru-RU");
        string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", culture);
        Console.WriteLine($"{now} {type,-7} - {text}");
    }
}