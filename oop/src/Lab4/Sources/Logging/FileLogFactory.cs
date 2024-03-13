using System;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

public class FileLogFactory : LogFactory
{
    public override Logger Create()
    {
        if (GlobalLogger == null)
        {
            GlobalLogger = new FileLogger(new CultureInfo("ru-RU"));
            return GlobalLogger;
        }

        throw new NotImplementedException();
    }
}