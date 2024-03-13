namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Storages;

public abstract class Storage
{
    protected Storage(double capacity, double powerConsumption)
    {
        Capacity = capacity;
        PowerConsumption = powerConsumption;
    }

    public double Capacity { get; }

    public double PowerConsumption { get; }
}