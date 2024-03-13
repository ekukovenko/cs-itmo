namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface ICpuBuilder
{
    ICpuBuilder WithModelName(string modelName);
    ICpuBuilder WithCoreFrequency(double coreFrequency);
    ICpuBuilder WithCoreAmount(double coreAmount);
    ICpuBuilder WithSocket(string socket);
    ICpuBuilder WithVideoCoreAvailability(bool videoCoreAvailability);
    ICpuBuilder AddMemoryFrequency(double memoryFrequency);
    ICpuBuilder WithTdpAmount(double tdp);
    ICpuBuilder WithPowerConsumption(double powerConsumption);
}