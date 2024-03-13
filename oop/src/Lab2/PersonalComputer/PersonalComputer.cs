using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class PersonalComputer
{
    public PersonalComputer(Motherboard motherboard, Cpu cpu, Bios bios, CpuCoolingSystem cpuCoolingSystem, IList<RAM> randomAccessMemories, XmpProfile? xmpProfile, IList<VideoCart>? videoCarts, IList<Ssd>? ssds, IList<Hdd>? hdds, Corpus corpus, PowerUnit powerUnit, WiFiAdapter? wiFiAdapter)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        Bios = bios;
        CpuCoolingSystem = cpuCoolingSystem;
        RandomAccessMemories = randomAccessMemories;
        XmpProfile = xmpProfile;
        VideoCarts = videoCarts;
        Ssds = ssds;
        Hdds = hdds;
        Corpus = corpus;
        PowerUnit = powerUnit;
        WiFiAdapter = wiFiAdapter;
    }

    public Motherboard Motherboard { get; }
    public Cpu Cpu { get; }
    public Bios Bios { get; }
    public CpuCoolingSystem CpuCoolingSystem { get; }
    public IList<RAM> RandomAccessMemories { get; }
    public XmpProfile? XmpProfile { get; }
    public IList<VideoCart>? VideoCarts { get; }
    public IList<Ssd>? Ssds { get; }
    public IList<Hdd>? Hdds { get; }
    public Corpus Corpus { get; }
    public PowerUnit PowerUnit { get; }
    public WiFiAdapter? WiFiAdapter { get; }

    public IPersonalComputerBuilder Direct(IPersonalComputerBuilder personalComputerBuilder)
    {
        if (personalComputerBuilder is null) throw new ArgumentNullException(nameof(personalComputerBuilder));

        if (Ssds is not null)
        {
            foreach (Ssd ssd in Ssds)
            {
                personalComputerBuilder.AddSsd(ssd);
            }
        }

        if (Hdds is not null)
        {
            foreach (Hdd hdd in Hdds)
            {
                personalComputerBuilder.AddHdd(hdd);
            }
        }

        if (VideoCarts is not null)
        {
            foreach (VideoCart videoCart in VideoCarts)
            {
                personalComputerBuilder.AddVideoCart(videoCart);
            }
        }

        foreach (RAM randomAccessMemory in RandomAccessMemories)
        {
            personalComputerBuilder.AddRandomAccessMemory(randomAccessMemory);
        }

        return personalComputerBuilder.WithMotherboard(Motherboard).WithCpu(Cpu).WithBios(Bios).WithCpuCoolingSystem(CpuCoolingSystem)
                .WithXmpProfile(XmpProfile).WithCorpus(Corpus).WithPowerUnit(PowerUnit).WithWiFiAdapter(WiFiAdapter);
    }
}