using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class TrailDataCalculationService
{
    public static double MoneySpent(Environment.Environment environment, double distance, Spaceship.Spaceship spaceship, double fuelCost)
    {
        const double exponentialImpulseEngineCoefficient = 2;
        ArgumentNullException.ThrowIfNull(spaceship);
        ArgumentNullException.ThrowIfNull(spaceship.ImpulseEngine);

        double fuelConsumption = spaceship.ImpulseEngine.FuelConsumption(distance);
        double additionalFuelCost = spaceship.ImpulseEngine.FuelConsumptionPerStart;

        double result = environment switch
        {
            HighDensityNebula _ when spaceship.JumpEngine != null => spaceship.JumpEngine.FuelConsumption(distance) *
                                                                     fuelCost,
            NitrideParticlesNebula _ when spaceship.ImpulseEngine is ImpulseEngineE => (fuelConsumption * fuelCost /
                exponentialImpulseEngineCoefficient) + additionalFuelCost,
            _ => (fuelConsumption * fuelCost) + additionalFuelCost,
        };

        return result;
    }

    public static double TimeSpent(double distance, Spaceship.Spaceship spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        if (spaceship.ImpulseEngine != null)
        {
            return distance / spaceship.ImpulseEngine.Speed;
        }

        throw new InvalidOperationException("No impulse engine");
    }
}