using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;

public interface ISsdBuilder
{
    ISsdBuilder WithConnectionType(SsdConnectionType connectionType);
    ISsdBuilder WithCapacity(double capacity);
    ISsdBuilder WithMaxWorkSpeed(double maxWorkSpeed);
    ISsdBuilder WithPowerConsumption(double powerConsumption);
}