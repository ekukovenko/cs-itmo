using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;

public class VideoCart
{
    public VideoCart(Dimensions dimensions, double videoMemoryAmount, string pcieVersion, double chipFrequency, double powerConsumption)
    {
        Dimensions = dimensions;
        VideoMemoryAmount = videoMemoryAmount;
        PcieVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public Dimensions Dimensions { get; }
    public double VideoMemoryAmount { get; }
    public string PcieVersion { get; }
    public double ChipFrequency { get; }
    public double PowerConsumption { get; }

    public IVideoCartBuilder Direct(IVideoCartBuilder videoCartBuilder)
    {
        if (videoCartBuilder is null) throw new ArgumentNullException(nameof(videoCartBuilder));

        return videoCartBuilder.WithDimensions(Dimensions).VideoMemoryAmount(VideoMemoryAmount)
            .WithPcieVersion(PcieVersion).WithChipFrequency(ChipFrequency).WithPowerConsumption(PowerConsumption);
    }
}