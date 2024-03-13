using Itmo.ObjectOrientedProgramming.Lab2.Components.Storages;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;

public class Ssd : Storage
{
    public Ssd(SsdConnectionType connectionType, double capacity, double maxWorkSpeed, double powerConsumption)
        : base(capacity, powerConsumption)
    {
        ConnectionType = connectionType;
        MaxWorkSpeed = maxWorkSpeed;
    }

    public SsdConnectionType ConnectionType { get; }
    public double MaxWorkSpeed { get; set; }
}