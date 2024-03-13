namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IXmpProfileBuilder
{
    IXmpProfileBuilder WithTimings(string timings);
    IXmpProfileBuilder WithVoltage(double voltage);
    IXmpProfileBuilder WithFrequency(double frequency);
}