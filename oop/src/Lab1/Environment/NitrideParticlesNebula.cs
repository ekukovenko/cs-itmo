using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NitrideParticlesNebula : Environment
{
    public NitrideParticlesNebula(IList<Obstacle> obstacles, DistanceOfPathSegment distance)
        : base(obstacles, distance)
    {
    }

    public override ShipState CanMoveThrough(IList<Obstacle> obstacles, Spaceship.Spaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        return spaceship.ImpulseEngine is null & spaceship.ImpulseEngine is not ImpulseEngineE ? ShipState.ShipLost : base.CanMoveThrough(obstacles, spaceship);
    }
}