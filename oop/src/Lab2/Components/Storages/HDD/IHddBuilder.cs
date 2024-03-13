namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IHddBuilder
{
    IHddBuilder WithCapacity(double capacity);
    IHddBuilder WithSpindleRotationSpeed(double spindleRotationSpeed);
    IHddBuilder WithPowerConsumption(double powerConsumption);
}