using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

public class ConsoleLogFactory : LogFactory
{
    public override Logger Create()
    {
        if (GlobalLogger == null)
        {
            GlobalLogger = new ConsoleLogger(new CultureInfo("ru-RU"));
            return GlobalLogger;
        }

        throw new NotImplementedException();
    }
}