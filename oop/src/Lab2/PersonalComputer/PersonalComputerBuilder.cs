using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class PersonalComputerBuilder : IPersonalComputerBuilder
{
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private Bios? _bios;
    private CpuCoolingSystem? _cpuCoolingSystem;
    private List<RAM>? _randomAccessMemories = new();
    private XmpProfile? _xmpProfile;
    private List<VideoCart>? _videoCarts = new();
    private List<Ssd>? _ssds = new();
    private List<Hdd>? _hdds = new();
    private Corpus? _corpus;
    private PowerUnit? _powerUnit;
    private WiFiAdapter? _wiFiAdapter;

    public IPersonalComputerBuilder WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public IPersonalComputerBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPersonalComputerBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public IPersonalComputerBuilder WithCpuCoolingSystem(CpuCoolingSystem cpuCoolingSystem)
    {
        _cpuCoolingSystem = cpuCoolingSystem;
        return this;
    }

    public IPersonalComputerBuilder AddRandomAccessMemory(RAM ram)
    {
        _randomAccessMemories?.Add(ram);
        return this;
    }

    public IPersonalComputerBuilder WithXmpProfile(XmpProfile? xmpProfile)
    {
        _xmpProfile = xmpProfile;
        return this;
    }

    public IPersonalComputerBuilder AddVideoCart(VideoCart? videoCart)
    {
        if (videoCart != null) _videoCarts?.Add(videoCart);
        return this;
    }

    public IPersonalComputerBuilder AddSsd(Ssd? ssd)
    {
        if (ssd != null) _ssds?.Add(ssd);
        return this;
    }

    public IPersonalComputerBuilder AddHdd(Hdd? hdd)
    {
        if (hdd != null) _hdds?.Add(hdd);
        return this;
    }

    public IPersonalComputerBuilder WithCorpus(Corpus corpus)
    {
        _corpus = corpus;
        return this;
    }

    public IPersonalComputerBuilder WithPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IPersonalComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }

    public PersonalComputerBuildResult Build()
    {
        if (_motherboard is null
            || _cpu is null
            || _bios is null
            || _cpuCoolingSystem is null
            || _randomAccessMemories is null
            || _corpus is null
            || _powerUnit is null) return new PersonalComputerBuildResult.NoRequiredComponents();

        var personalComputer = new PersonalComputer(
            _motherboard,
            _cpu,
            _bios,
            _cpuCoolingSystem,
            _randomAccessMemories,
            _xmpProfile,
            _videoCarts,
            _ssds,
            _hdds,
            _corpus,
            _powerUnit,
            _wiFiAdapter);

        ValidationResults validationResult = ValidationService.PersonalComputerValidation(personalComputer);
        return validationResult switch
        {
            ValidationResults.ValidationError => new PersonalComputerBuildResult.СomponentsDontFitEachOther(
                personalComputer, validationResult.Comment),
            ValidationResults.SuccessWithWarranty => new PersonalComputerBuildResult.SuccessWithWarrantyDisclaimer(
                personalComputer, validationResult.Comment),
            _ => new PersonalComputerBuildResult.Success(personalComputer, "Success"),
        };
    }
}