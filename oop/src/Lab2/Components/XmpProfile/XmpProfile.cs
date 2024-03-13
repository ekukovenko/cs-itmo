using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class XmpProfile
{
    public XmpProfile(string timings, double voltage, double frequency)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Timings { get; }
    public double Voltage { get; }
    public double Frequency { get; }

    public IXmpProfileBuilder Direct(IXmpProfileBuilder xmpProfileBuilder)
    {
        if (xmpProfileBuilder is null) throw new ArgumentNullException(nameof(xmpProfileBuilder));

        return xmpProfileBuilder.WithTimings(Timings).WithVoltage(Voltage).WithFrequency(Frequency);
    }
}