using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class HighDensityNebula : Environment
{
    public HighDensityNebula(IList<Obstacle> obstacles, DistanceOfPathSegment distance)
    : base(obstacles, distance)
    {
    }

    public override ShipState CanMoveThrough(IList<Obstacle> obstacles, Spaceship.Spaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        if (spaceship.JumpEngine is null || Distance > spaceship.JumpEngine.JumpDistance)
        {
            return ShipState.ShipLost;
        }

        return base.CanMoveThrough(obstacles, spaceship);
    }
}