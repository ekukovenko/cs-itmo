using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class BiosBuilder : IBiosBuilder
{
    private readonly List<Cpu> _supportedProcessors = new();
    private string? _type;
    private string? _version;

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder AddSupportedProcessor(Cpu supportedProcessor)
    {
        _supportedProcessors.Add(supportedProcessor);
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _supportedProcessors ?? throw new ArgumentNullException(nameof(_supportedProcessors)));
    }
}