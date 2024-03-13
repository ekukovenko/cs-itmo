using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public abstract class Deflector : IDeflector
{
    protected Deflector(double numOfAsteroids, double numOfMeteorites, bool isPhotonicShieldActivated)
    {
        PhotonicShield = 0;
        DeflectorProtection = numOfAsteroids * numOfMeteorites;
        if (numOfAsteroids < 0 || numOfMeteorites < 0)
        {
            throw new ArgumentException("Negative value");
        }

        if (isPhotonicShieldActivated == true)
        {
            PhotonicShield = 3;
        }
    }

    private double PhotonicShield { get; set; }
    private double DeflectorProtection { get; set; }

    public virtual ShipState TakeDamage(Obstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);

        switch (obstacle)
        {
            case ObstacleFlash when PhotonicShield > 0:
                PhotonicShield -= 1;
                return ShipState.DamageNotCritical;

            case ObstacleFlash when PhotonicShield is 0:
                return ShipState.CrewWasKilled;

            case ObstacleWhale:
                return ShipState.ShipDestroyed;

            default:
                DeflectorProtection -= obstacle.Damage;
                return (DeflectorProtection <= 0) ? ShipState.DeflectorDestroyed : ShipState.DamageNotCritical;
        }
    }
}