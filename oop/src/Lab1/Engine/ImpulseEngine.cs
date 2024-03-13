namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public abstract class ImpulseEngine : IEngine
{
    protected ImpulseEngine(double speed, double fuelconsumptionPerStart, double fuelConsumptionCoef)
    {
        Speed = speed;
        FuelConsumptionPerStart = fuelconsumptionPerStart;
        FuelConsumptionCoef = fuelConsumptionCoef;
    }

    public double Speed { get; }
    public double FuelConsumptionPerStart { get; }
    private double FuelConsumptionCoef { get; }
    private double FuelConsumed { get; set; }

    public double FuelConsumption(double distance)
    {
        FuelConsumed = distance * FuelConsumptionCoef;
        return FuelConsumed;
    }
}