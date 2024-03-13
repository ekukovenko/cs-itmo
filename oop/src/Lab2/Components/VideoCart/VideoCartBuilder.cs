using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;

public class VideoCartBuilder : IVideoCartBuilder
{
    private Dimensions? _dimensions;
    private double _videoMemoryAmount;
    private string? _pcieVersion;
    private double _chipFrequency;
    private double _powerConsumption;

    public IVideoCartBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IVideoCartBuilder VideoMemoryAmount(double videoMemoryAmount)
    {
        _videoMemoryAmount = videoMemoryAmount;
        return this;
    }

    public IVideoCartBuilder WithPcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public IVideoCartBuilder WithChipFrequency(double chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public IVideoCartBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public VideoCart Build()
    {
        return new VideoCart(
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _videoMemoryAmount,
            _pcieVersion ?? throw new ArgumentNullException(nameof(_pcieVersion)),
            _chipFrequency,
            _powerConsumption);
    }
}