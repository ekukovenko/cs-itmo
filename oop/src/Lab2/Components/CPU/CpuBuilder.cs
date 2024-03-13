using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class CpuBuilder : ICpuBuilder
{
    private string? _modelName;
    private double _coreFrequency;
    private double _coreAmount;
    private string? _socket;
    private bool _videoCore;
    private List<double> _memoryFrequencies = new();
    private double _tdp;
    private double _powerConsumption;

    public ICpuBuilder WithModelName(string modelName)
    {
        _modelName = modelName;
        return this;
    }

    public ICpuBuilder WithCoreFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreAmount(double coreAmount)
    {
        _coreAmount = coreAmount;
        return this;
    }

    public ICpuBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithVideoCoreAvailability(bool videoCoreAvailability)
    {
        _videoCore = videoCoreAvailability;
        return this;
    }

    public ICpuBuilder AddMemoryFrequency(double memoryFrequency)
    {
        _memoryFrequencies.Add(memoryFrequency);
        return this;
    }

    public ICpuBuilder WithTdpAmount(double tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _modelName ?? throw new ArgumentNullException(nameof(_modelName)),
            _coreFrequency,
            _coreAmount,
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _videoCore,
            _memoryFrequencies ?? throw new ArgumentNullException(nameof(_memoryFrequencies)),
            _tdp,
            _powerConsumption);
    }
}