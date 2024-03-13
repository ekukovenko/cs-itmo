using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Trails;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class FindOptimalShipService
{
    public static Spaceship.Spaceship? FindOptimalShip(IList<Spaceship.Spaceship> spaceships, Trail trail, double fuelCost)
    {
        ArgumentNullException.ThrowIfNull(spaceships);

        var optimalShip = spaceships
            .Select(spaceship =>
            {
                trail.TrailTimeMoneySpend(spaceship, fuelCost);
                return new
                {
                    Spaceship = spaceship,
                    TrailState = trail.TrailResult(spaceship),
                    TimeSpent = trail.TimeSpent,
                    MoneySpent = trail.MoneySpent,
                };
            })
            .Where(result => result.TrailState != ShipState.ShipDestroyed &&
                             result.TrailState != ShipState.CrewWasKilled &&
                             result.TrailState != ShipState.ShipLost).MinBy(result => result.MoneySpent);

        return optimalShip?.Spaceship;
    }
}