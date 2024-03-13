using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public abstract class LogFactory
{
    protected static Logger? GlobalLogger { get; set; }
    public static Logger Get()
    {
        if (GlobalLogger != null)
            return GlobalLogger;
        throw new NotImplementedException();
    }

    public abstract Logger Create();
}
