using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Motherboard
{
    public Motherboard(string cpuSocket, double pcieLinesAmount, double sataPortsAmount, Chipset chipset, string ddr, double ramTablesAmount, string formFactor, Bios bios, bool wiFiModule)
    {
        CpuSocket = cpuSocket;
        PcieLinesAmount = pcieLinesAmount;
        SataPortsAmount = sataPortsAmount;
        Chipset = chipset;
        Ddr = ddr;
        RamTablesAmount = ramTablesAmount;
        FormFactor = formFactor;
        Bios = bios;
        WiFiModule = wiFiModule;
    }

    public string CpuSocket { get; }
    public double PcieLinesAmount { get; }
    public double SataPortsAmount { get; }
    public Chipset Chipset { get; }
    public string Ddr { get; }
    public double RamTablesAmount { get; }
    public string FormFactor { get; }
    public Bios Bios { get; }
    public bool WiFiModule { get; }

    public IMotherboardBuilder Direct(IMotherboardBuilder motherboardBuilder)
    {
        if (motherboardBuilder is null) throw new ArgumentNullException(nameof(motherboardBuilder));

        return motherboardBuilder.WithDdrStandard(Ddr).WithFormFactor(FormFactor).WithChipset(Chipset).WithBios(Bios)
            .WithSocket(CpuSocket).WithPcieLinesAmount(PcieLinesAmount).WithSataPortsAmount(SataPortsAmount)
            .WithRamTablesAmount(RamTablesAmount).WithWiFiModule(WiFiModule);
    }
}