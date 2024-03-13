using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IPersonalComputerBuilder
{
    IPersonalComputerBuilder WithMotherboard(Motherboard motherboard);
    IPersonalComputerBuilder WithCpu(Cpu cpu);
    IPersonalComputerBuilder WithBios(Bios bios);
    IPersonalComputerBuilder WithCpuCoolingSystem(CpuCoolingSystem cpuCoolingSystem);
    IPersonalComputerBuilder AddRandomAccessMemory(RAM ram);
    IPersonalComputerBuilder WithXmpProfile(XmpProfile? xmpProfile);
    IPersonalComputerBuilder AddVideoCart(VideoCart? videoCart);
    IPersonalComputerBuilder AddSsd(Ssd? ssd);
    IPersonalComputerBuilder AddHdd(Hdd? hdd);
    IPersonalComputerBuilder WithCorpus(Corpus corpus);
    IPersonalComputerBuilder WithPowerUnit(PowerUnit powerUnit);
    IPersonalComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter);

    PersonalComputerBuildResult Build();
}
