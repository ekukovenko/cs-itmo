using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceship;
using Itmo.ObjectOrientedProgramming.Lab1.Trails;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    [Theory]
    [InlineData(DistanceOfPathSegment.Medium, ShipState.ShipLost)]
    public void TrailCheckPleasureShuttleHighDensityNebulaFailed(
        DistanceOfPathSegment distance,
        ShipState expected)
    {
        // Arrange
        var pleasureShuttle = new Shuttle();

        IList<Obstacle> obstacles = new List<Obstacle>();
        var environment = new HighDensityNebula(obstacles, distance);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        // Act
        ShipState trailState = trail.TrailResult(pleasureShuttle);

        // Assert
        Assert.Equal(expected, trailState);
    }

    [Theory]
    [InlineData(DistanceOfPathSegment.Medium, ShipState.ShipLost)]
    public void TrailCheckAvgurHighDensityNebulaFailed(
        DistanceOfPathSegment distance,
        ShipState expected)
    {
        // Arrange
        const bool isPhotonDeflectorActivated = false;
        var avgur = new Avgur(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new List<Obstacle>();
        var environment = new HighDensityNebula(obstacles, distance);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        // Act
        ShipState trailState = trail.TrailResult(avgur);

        // Assert
        Assert.Equal(expected, trailState);
    }

    [Theory]
    [InlineData(DistanceOfPathSegment.Small, false, ShipState.CrewWasKilled)]
    public void TrailCheckVaclasHighDensityNebulaWithAntimatterOutbreakPhotonDeflectorOffFailed(
        DistanceOfPathSegment distance,
        bool isPhotonDeflectorActivated,
        ShipState expected)
    {
        // Arrange
        var vaclas = new Vaclas(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new[] { new ObstacleFlash() };
        var environment = new HighDensityNebula(obstacles, distance);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        // Act
        ShipState trailState = trail.TrailResult(vaclas);

        // Assert
        Assert.Equal(expected, trailState);
    }

    [Theory]
    [InlineData(DistanceOfPathSegment.Small, true, ShipState.Normal)]
    public void TrailCheckVaclasHighDensityNebulaWithAntimatterOutbreakPhotonDeflectorOnSuccess(
        DistanceOfPathSegment distance,
        bool isPhotonDeflectorActivated,
        ShipState expected)
    {
        // Arrange
        var vaclas = new Vaclas(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new[] { new ObstacleFlash() };
        var environment = new HighDensityNebula(obstacles, distance);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        // Act
        ShipState trailState = trail.TrailResult(vaclas);

        // Assert
        Assert.Equal(expected, trailState);
    }

    [Theory]
    [InlineData(DistanceOfPathSegment.Small, false, ShipState.ShipDestroyed)]
    public void TrailCheckVaclasNitrideParticlesNebulaCosmicWhaleDestroyed(
        DistanceOfPathSegment distance,
        bool isPhotonDeflectorActivated,
        ShipState expected)
    {
        // Arrange
        var vaclas = new Vaclas(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new[] { new ObstacleWhale() };
        var environment = new NitrideParticlesNebula(obstacles, distance);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        // Act
        ShipState trailState = trail.TrailResult(vaclas);

        // Assert
        Assert.Equal(expected, trailState);
    }

    [Theory]
    [InlineData(DistanceOfPathSegment.Small, false, ShipState.DeflectorDestroyed)]
    public void TrailCheckAvgurNitrideParticlesNebulaCosmicWhaleDeflectorDamaged(
        DistanceOfPathSegment distance,
        bool isPhotonDeflectorActivated,
        ShipState expected)
    {
        // Arrange
        var avgur = new Avgur(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new[] { new ObstacleWhale() };
        var environment = new NitrideParticlesNebula(obstacles, distance);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        // Act
        ShipState trailState = trail.TrailResult(avgur);

        // Assert
        Assert.Equal(expected, trailState);
    }

    [Theory]
    [InlineData(DistanceOfPathSegment.Small, false, ShipState.Normal)]
    public void TrailCheckMeredianNitrideParticlesNebulaCosmicWhaleDeflectorSuccess(
        DistanceOfPathSegment distance,
        bool isPhotonDeflectorActivated,
        ShipState expected)
    {
        // Arrange
        var meredian = new Meredian(isPhotonDeflectorActivated);

        IList<Obstacle> obstacles = new[] { new ObstacleWhale() };
        var environment = new NitrideParticlesNebula(obstacles, distance);
        IReadOnlyCollection<Environment.Environment> pathSegment = new List<Environment.Environment> { environment };
        var trail = new Trail(pathSegment);

        // Act
        ShipState trailState = trail.TrailResult(meredian);

        // Assert
        Assert.Equal(expected, trailState);
    }
}