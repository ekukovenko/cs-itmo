using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Bios
{
    public Bios(string type, string version, IList<Cpu> supportedProcessors)
    {
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public string Type { get; }
    public string Version { get; }
    public IList<Cpu> SupportedProcessors { get; }

    public IBiosBuilder Direct(IBiosBuilder biosBuilder)
    {
        if (biosBuilder is null) throw new ArgumentNullException(nameof(biosBuilder));

        foreach (Cpu supportedProcessor in SupportedProcessors)
        {
            biosBuilder.AddSupportedProcessor(supportedProcessor);
        }

        return biosBuilder.WithType(Type).WithVersion(Version);
    }
}