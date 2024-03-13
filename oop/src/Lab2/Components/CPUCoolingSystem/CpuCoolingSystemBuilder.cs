using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CPUCoolingSystem;

public class CpuCoolingSystemBuilder : ICpuCoolingSystemBuilder
{
    private readonly List<string> _supportedSockets = new();
    private Dimensions? _dimensions;
    private double _tpd;

    public ICpuCoolingSystemBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ICpuCoolingSystemBuilder AddSupportedSocket(string supportedSocket)
    {
        _supportedSockets.Add(supportedSocket);
        return this;
    }

    public ICpuCoolingSystemBuilder WithTpd(double tpd)
    {
        _tpd = tpd;
        return this;
    }

    public CpuCoolingSystem Build()
    {
        return new CpuCoolingSystem(
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _supportedSockets,
            _tpd);
    }
}