using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components.CPUCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class CpuCoolingSystem
{
    public CpuCoolingSystem(Dimensions dimensions, IList<string> supportedSockets, double tpd)
    {
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        Tdp = tpd;
    }

    public Dimensions Dimensions { get; }
    public IList<string> SupportedSockets { get; }
    public double Tdp { get; }

    public ICpuCoolingSystemBuilder Direct(ICpuCoolingSystemBuilder cpuCoolingSystemBuilder)
    {
        if (cpuCoolingSystemBuilder is null) throw new ArgumentNullException(nameof(cpuCoolingSystemBuilder));

        foreach (string supportedSocket in SupportedSockets)
        {
            cpuCoolingSystemBuilder.AddSupportedSocket(supportedSocket);
        }

        return cpuCoolingSystemBuilder.WithDimensions(Dimensions).WithTpd(Tdp);
    }
}