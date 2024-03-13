using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Trails;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class OptimalShipTests
{
    [Fact]
    public void OptimalShipSimpleSpacePleasureShuttleAndVaclasChoosePleasureSuttle()
    {
        // Arrange
        const bool isPhotonDeflectorActivated = false;
        var pleasureShuttle = new Shuttle();
        var vaclas = new Vaclas(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new List<Obstacle>();
        IList<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { pleasureShuttle, vaclas };
        var environment = new Space(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        var miningGuild = new MiningGuild(5);

        // Act
        Spaceship.Spaceship expected = pleasureShuttle;
        Spaceship.Spaceship? spaceship = FindOptimalShipService.FindOptimalShip(spaceships, trail, miningGuild.FuelPrice);

        // Assert
        Assert.Equal(expected, spaceship);
    }

    [Fact]
    public void OptimalShipHighDensityNebulaAvgurAndStellaChooseStella()
    {
        // Arrange
        const bool isPhotonDeflectorActivated = false;
        var avgur = new Avgur(isPhotonDeflectorActivated);
        var stella = new Stella(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new List<Obstacle>();
        IList<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { avgur, stella };
        var environment = new HighDensityNebula(obstacles, DistanceOfPathSegment.Medium);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        var miningGuild = new MiningGuild(5);

        // Act
        Spaceship.Spaceship expected = stella;
        Spaceship.Spaceship? spaceship = FindOptimalShipService.FindOptimalShip(spaceships, trail, miningGuild.FuelPrice);

        // Assert
        Assert.Equal(expected, spaceship);
    }

    [Fact]
    public void OptimalShipNitrideParticlesNebulaPleasureShuttleAndVaclasChooseVaclas()
    {
        // Arrange
        const bool isPhotonDeflectorActivated = false;
        var pleasureShuttle = new Shuttle();
        var vaclas = new Vaclas(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new List<Obstacle>();
        IList<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { pleasureShuttle, vaclas };
        var environment = new NitrideParticlesNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        var miningGuild = new MiningGuild(5);

        // Act
        Spaceship.Spaceship expected = vaclas;
        Spaceship.Spaceship? spaceship = FindOptimalShipService.FindOptimalShip(spaceships, trail, miningGuild.FuelPrice);

        // Assert
        Assert.Equal(expected, spaceship);
    }

    [Fact]
    public void OptimalShipHighDensityNebulaStellaAndAvgurChooseAvgur()
    {
        // Arrange
        const bool isPhotonDeflectorActivated = false;
        var avgur = new Avgur(isPhotonDeflectorActivated);
        var stella = new Stella(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new List<Obstacle> { new ObstacleAsteroid(), new ObstacleAsteroid(), new ObstacleAsteroid(), new ObstacleMeteorite() };
        IList<Spaceship.Spaceship> spaceships = new List<Spaceship.Spaceship> { avgur, stella };
        var environment = new HighDensityNebula(obstacles, DistanceOfPathSegment.Small);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);
        var miningGuild = new MiningGuild(5);

        // Act
        Spaceship.Spaceship expected = avgur;
        Spaceship.Spaceship? spaceship = FindOptimalShipService.FindOptimalShip(spaceships, trail, miningGuild.FuelPrice);

        // Assert
        Assert.Equal(expected, spaceship);
    }
}