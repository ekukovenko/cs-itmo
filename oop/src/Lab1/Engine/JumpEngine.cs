namespace Itmo.ObjectOrientedProgramming.Lab1.Engine;

public class JumpEngine : IEngine
{
    protected JumpEngine(double jumpDistance, double fuelConsumptionCoef)
    {
        JumpDistance = jumpDistance;
        FuelConsumptionCoef = fuelConsumptionCoef;
    }

    public double JumpDistance { get; }
    private double FuelConsumptionCoef { get; }
    private double FuelConsumed { get; set; }
    public double FuelConsumption(double distance)
    {
        FuelConsumed = distance * FuelConsumptionCoef;
        return FuelConsumed;
    }
}