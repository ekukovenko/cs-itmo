using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.CPUCoolingSystem;

public interface ICpuCoolingSystemBuilder
{
    ICpuCoolingSystemBuilder WithDimensions(Dimensions dimensions);
    ICpuCoolingSystemBuilder AddSupportedSocket(string supportedSocket);
    ICpuCoolingSystemBuilder WithTpd(double tpd);
}