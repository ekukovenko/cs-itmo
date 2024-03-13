using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class RAMBuilder : IRAMBuilder
{
    private double _freeMemoryAmount;
    private List<JedecVoltageFrequency> _supportedJedecVoltagePairs = new();
    private List<XmpProfile> _availableXmpProfiles = new();
    private string? _formFactor;
    private string? _ddr;
    private double _powerConsumption;

    public IRAMBuilder WithFreeMemoryAmount(double freeMemoryAmount)
    {
        _freeMemoryAmount = freeMemoryAmount;
        return this;
    }

    public IRAMBuilder AddAvailableJedecVoltageFrequency(JedecVoltageFrequency jedecVoltageFrequency)
    {
        _supportedJedecVoltagePairs.Add(jedecVoltageFrequency);
        return this;
    }

    public IRAMBuilder AddXmpProfile(XmpProfile xmpProfile)
    {
        _availableXmpProfiles.Add(xmpProfile);
        return this;
    }

    public IRAMBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public IRAMBuilder WithDdrStandard(string ddr)
    {
        _ddr = ddr;
        return this;
    }

    public IRAMBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public RAM Build()
    {
        return new RAM(
            _freeMemoryAmount,
            _supportedJedecVoltagePairs ?? throw new ArgumentNullException(nameof(_supportedJedecVoltagePairs)),
            _availableXmpProfiles ?? throw new ArgumentNullException(nameof(_availableXmpProfiles)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddr ?? throw new ArgumentNullException(nameof(_ddr)),
            _powerConsumption);
    }
}