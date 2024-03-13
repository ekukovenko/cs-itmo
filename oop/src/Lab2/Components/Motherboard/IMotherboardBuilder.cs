using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithSocket(string socket);
    IMotherboardBuilder WithPcieLinesAmount(double pcieLinesAmount);
    IMotherboardBuilder WithSataPortsAmount(double sataPortsAmount);
    IMotherboardBuilder WithChipset(Chipset chipset);
    IMotherboardBuilder WithDdrStandard(string ddr);
    IMotherboardBuilder WithRamTablesAmount(double ramTablesAmount);
    IMotherboardBuilder WithFormFactor(string formFactor);
    IMotherboardBuilder WithBios(Bios bios);
    IMotherboardBuilder WithWiFiModule(bool wiFiModule);
}