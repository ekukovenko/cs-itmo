using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Cpu
{
    public Cpu(string modelName, double coreFrequency, double coreAmount, string socket, bool videoCore, IList<double> memoryFrequencies, double tdp, double powerConsumption)
    {
        ModelName = modelName;
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        CpuSocket = socket;
        VideoCore = videoCore;
        MemoryFrequencies = memoryFrequencies;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public string ModelName { get; set; }
    public double CoreFrequency { get; }
    public double CoreAmount { get; }
    public string CpuSocket { get; }
    public bool VideoCore { get; }
    public IList<double> MemoryFrequencies { get; }
    public double Tdp { get; }
    public double PowerConsumption { get; }

    public ICpuBuilder Direct(ICpuBuilder cpuBuilder)
    {
        if (cpuBuilder is null) throw new ArgumentNullException(nameof(cpuBuilder));

        foreach (double frequency in MemoryFrequencies)
        {
            cpuBuilder.AddMemoryFrequency(frequency);
        }

        return cpuBuilder.WithCoreFrequency(CoreFrequency).WithCoreAmount(CoreAmount).WithSocket(CpuSocket)
            .WithVideoCoreAvailability(VideoCore).WithTdpAmount(Tdp).WithPowerConsumption(PowerConsumption);
    }
}