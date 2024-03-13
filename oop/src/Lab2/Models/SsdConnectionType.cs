namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record SsdConnectionType()
{
    public bool PcieConnection { get; init; }
    public bool SataConnection { get; init; }
}