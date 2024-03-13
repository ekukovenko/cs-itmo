using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class FileLogFactory : LogFactory
{
    public override Logger Create()
    {
        if (GlobalLogger == null)
        {
            GlobalLogger = new FileLogger();
            return GlobalLogger;
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}