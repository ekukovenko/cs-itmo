using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public abstract class Environment
{
    protected Environment(IList<Obstacle> obstacles, DistanceOfPathSegment distance)
    {
        Obstacles = obstacles;
        Distance = distance.ConvertDistance();
    }

    public double Distance { get; }
    public IList<Obstacle> Obstacles { get; private set; }

    public virtual ShipState CanMoveThrough(IList<Obstacle> obstacles, Spaceship.Spaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);
        ArgumentNullException.ThrowIfNull(obstacles);

        if (obstacles.Any(obstacle => spaceship.AntiNeutrinoEmitter is false && obstacle is ObstacleWhale))
        {
            return spaceship.DefaultDeflector is Deflector3
                ? ShipState.DeflectorDestroyed
                : ShipState.ShipDestroyed;
        }

        bool deflectorDestroyed = obstacles.Any(obstacle =>
            spaceship.DefaultDeflector is not null &&
            spaceship.DefaultDeflector.TakeDamage(obstacle) == ShipState.DeflectorDestroyed);
        if (deflectorDestroyed)
        {
            return ShipState.DeflectorDestroyed;
        }

        bool crewKilled = obstacles.Any(obstacle =>
            spaceship.DefaultDeflector is not null && obstacle.CrewKill &&
            spaceship.DefaultDeflector.TakeDamage(obstacle) == ShipState.CrewWasKilled);
        if (crewKilled)
        {
            return ShipState.CrewWasKilled;
        }

        bool shipDestroyed = obstacles.Any(obstacle =>
            spaceship.DefaultDeflector is not null &&
            spaceship.DefaultDeflector.TakeDamage(obstacle) == ShipState.DeflectorDestroyed &&
            spaceship.StrengthClassDefault.TakeDamage(obstacle) == ShipState.ShipDestroyed);

        return shipDestroyed ? ShipState.ShipDestroyed : ShipState.Normal;
    }
}