using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Storages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Hdd : Storage
{
    public Hdd(double capacity, double spindleRotationSpeed, double powerConsumption)
    : base(capacity, powerConsumption)
    {
        SpindleRotationSpeed = spindleRotationSpeed;
    }

    public double SpindleRotationSpeed { get; }

    public IHddBuilder Direct(IHddBuilder hddBuilder)
    {
        if (hddBuilder is null) throw new ArgumentNullException(nameof(hddBuilder));

        return hddBuilder.WithCapacity(Capacity).WithSpindleRotationSpeed(SpindleRotationSpeed)
            .WithPowerConsumption(PowerConsumption);
    }
}