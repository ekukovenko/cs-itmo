using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

public abstract class StrengthClassDefault
{
    protected StrengthClassDefault(double asteroidsAmount, double meteoritesAmount)
    {
        if (asteroidsAmount < 0 || meteoritesAmount < 0)
        {
            throw new ArgumentException("Negative value");
        }

        StrengthClassProtection = asteroidsAmount * meteoritesAmount;
    }

    private double StrengthClassProtection { get; set; }

    public ShipState TakeDamage(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        StrengthClassProtection -= obstacle.Damage;

        return StrengthClassProtection <= 0 ? ShipState.ShipDestroyed : ShipState.DamageNotCritical;
    }
}