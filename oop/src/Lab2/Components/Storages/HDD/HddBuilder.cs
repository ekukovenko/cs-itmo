namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class HddBuilder : IHddBuilder
{
    private double _capacity;
    private double _spindleRotationSpeed;
    private double _powerConsumption;

    public IHddBuilder WithCapacity(double capacity)
    {
        _capacity = capacity;
        return this;
    }

    public IHddBuilder WithSpindleRotationSpeed(double spindleRotationSpeed)
    {
        _spindleRotationSpeed = spindleRotationSpeed;
        return this;
    }

    public IHddBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Build()
    {
        return new Hdd(
            _capacity,
            _spindleRotationSpeed,
            _powerConsumption);
    }
}