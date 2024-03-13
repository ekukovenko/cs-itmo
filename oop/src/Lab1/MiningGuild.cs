namespace Itmo.ObjectOrientedProgramming.Lab1;

public class MiningGuild
{
    public MiningGuild(double fuelPrice)
    {
        FuelPrice = fuelPrice;
    }

    public double FuelPrice { get; private set; }
}