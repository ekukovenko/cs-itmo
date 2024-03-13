namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IBiosBuilder
{
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(string version);
    IBiosBuilder AddSupportedProcessor(Cpu supportedProcessor);
}