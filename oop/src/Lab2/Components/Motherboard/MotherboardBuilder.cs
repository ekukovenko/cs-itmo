using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class MotherboardBuilder : IMotherboardBuilder
{
    private string? _cpuSocket;
    private double _pcieLinesAmount;
    private double _sataPortsAmount;
    private Chipset? _chipset;
    private string? _ddr;
    private double _ramTablesAmount;
    private string? _formFactor;
    private Bios? _bios;
    private bool _wiFiModule;

    public IMotherboardBuilder WithSocket(string socket)
    {
        _cpuSocket = socket;
        return this;
    }

    public IMotherboardBuilder WithPcieLinesAmount(double pcieLinesAmount)
    {
        _pcieLinesAmount = pcieLinesAmount;
        return this;
    }

    public IMotherboardBuilder WithSataPortsAmount(double sataPortsAmount)
    {
        _sataPortsAmount = sataPortsAmount;
        return this;
    }

    public IMotherboardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherboardBuilder WithDdrStandard(string ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IMotherboardBuilder WithRamTablesAmount(double ramTablesAmount)
    {
        _ramTablesAmount = ramTablesAmount;
        return this;
    }

    public IMotherboardBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IMotherboardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IMotherboardBuilder WithWiFiModule(bool wiFiModule)
    {
        _wiFiModule = wiFiModule;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _cpuSocket ?? throw new ArgumentNullException(nameof(_cpuSocket)),
            _pcieLinesAmount,
            _sataPortsAmount,
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _ramTablesAmount,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _wiFiModule);
    }
}