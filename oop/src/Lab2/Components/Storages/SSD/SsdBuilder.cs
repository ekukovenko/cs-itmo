using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;

public class SsdBuilder : ISsdBuilder
{
    private SsdConnectionType? _connectionType;
    private double _capacity;
    private double _maxWorkSpeed;
    private double _powerConsumption;

    public ISsdBuilder WithConnectionType(SsdConnectionType connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public ISsdBuilder WithCapacity(double capacity)
    {
        _capacity = capacity;
        return this;
    }

    public ISsdBuilder WithMaxWorkSpeed(double maxWorkSpeed)
    {
        _maxWorkSpeed = maxWorkSpeed;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _connectionType ?? throw new ArgumentNullException(nameof(_connectionType)),
            _capacity,
            _maxWorkSpeed,
            _powerConsumption);
    }
}