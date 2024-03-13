using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;

public interface IVideoCartBuilder
{
    IVideoCartBuilder WithDimensions(Dimensions dimensions);
    IVideoCartBuilder VideoMemoryAmount(double videoMemoryAmount);
    IVideoCartBuilder WithPcieVersion(string pcieVersion);
    IVideoCartBuilder WithChipFrequency(double chipFrequency);
    IVideoCartBuilder WithPowerConsumption(double powerConsumption);
}