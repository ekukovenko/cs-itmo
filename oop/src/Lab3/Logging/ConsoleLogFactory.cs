using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class ConsoleLogFactory : LogFactory
{
    public override Logger Create()
    {
        if (GlobalLogger == null)
        {
            GlobalLogger = new ConsoleLogger();
            return GlobalLogger;
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}