using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

public abstract class Logger
{
    private readonly CultureInfo _cultureInfo;

    protected Logger(CultureInfo cultureInfo)
    {
        _cultureInfo = cultureInfo;
    }

    public void Error(string text) { Log("ERROR", text); }
    public void Info(string text) { Log("INFO", text); }
    public void Warning(string text) { Log("WARNING", text); }
    protected string GetNowDateTime()
    {
        return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", _cultureInfo);
    }

    protected abstract void Log(string level, string text);
}