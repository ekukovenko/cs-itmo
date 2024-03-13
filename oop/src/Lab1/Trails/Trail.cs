using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trails;

public class Trail
{
    public Trail(IReadOnlyCollection<Environment.Environment> pathSegments)
    {
        PathSegments = pathSegments;
    }

    public double TimeSpent { get; private set; }
    public double MoneySpent { get; private set; }
    private IReadOnlyCollection<Environment.Environment> PathSegments { get; }

    public void TrailTimeMoneySpend(Spaceship.Spaceship spaceship, double fuelCost)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        TimeSpent = PathSegments.Sum(environment =>
            TrailDataCalculationService.TimeSpent(environment.Distance, spaceship));
        MoneySpent = TimeSpent * PathSegments.Sum(environment =>
            TrailDataCalculationService.MoneySpent(environment, environment.Distance, spaceship, fuelCost));
    }

    public ShipState TrailResult(Spaceship.Spaceship spaceship)
    {
        return PathSegments.Select(environment => environment.CanMoveThrough(environment.Obstacles, spaceship)).FirstOrDefault();
    }
}