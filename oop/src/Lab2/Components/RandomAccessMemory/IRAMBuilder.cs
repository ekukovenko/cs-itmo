using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IRAMBuilder
{
    IRAMBuilder WithFreeMemoryAmount(double freeMemoryAmount);
    IRAMBuilder AddAvailableJedecVoltageFrequency(JedecVoltageFrequency jedecVoltageFrequency);
    IRAMBuilder AddXmpProfile(XmpProfile xmpProfile);
    IRAMBuilder WithFormFactor(string formFactor);
    IRAMBuilder WithDdrStandard(string ddr);
    IRAMBuilder WithPowerConsumption(double powerConsumption);
}