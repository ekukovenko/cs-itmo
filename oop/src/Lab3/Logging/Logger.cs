namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public abstract class Logger
{
    public void Info(string text) { Log("INFO", text); }
    public void Warning(string text) { Log("WARNING", text); }
    public void Error(string text) { Log("ERROR", text); }
    protected abstract void Log(string type, string text);
}
