using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class XmpProfileBuilder : IXmpProfileBuilder
{
    private string? _timings;
    private double _voltage;
    private double _frequency;

    public IXmpProfileBuilder WithTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public IXmpProfileBuilder WithVoltage(double voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpProfileBuilder WithFrequency(double frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XmpProfile Build()
    {
        return new XmpProfile(
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _voltage,
            _frequency);
    }
}