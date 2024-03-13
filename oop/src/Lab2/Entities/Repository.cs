using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Repository
{
    private static readonly object Lock = new();
    private static Repository? _instance;
    private Repository() { }
    public static Repository Instance
    {
        get
        {
            if (_instance is not null)
                return _instance;
            lock (Lock)
            {
             return _instance = new Repository();
            }
        }
    }

    public ICollection<Motherboard> Motherboards { get; } = new Collection<Motherboard>();
    public ICollection<Cpu> Cpus { get; } = new Collection<Cpu>();
    public ICollection<Bios> Bioses { get; } = new Collection<Bios>();
    public ICollection<XmpProfile> XmpProfiles { get; } = new Collection<XmpProfile>();
    public ICollection<VideoCart> VideoCarts { get; } = new Collection<VideoCart>();
    public ICollection<RAM> RandomAccessMemories { get; } = new Collection<RAM>();
    public ICollection<CpuCoolingSystem> CpuCoolingSystems { get; } = new Collection<CpuCoolingSystem>();
    public ICollection<Ssd> Ssds { get; } = new Collection<Ssd>();
    public ICollection<Hdd> Hdds { get; } = new Collection<Hdd>();
    public ICollection<Corpus> Corpuses { get; } = new Collection<Corpus>();
    public ICollection<PowerUnit> PowerUnits { get; } = new Collection<PowerUnit>();
    public ICollection<WiFiAdapter> WiFiAdapters { get; } = new Collection<WiFiAdapter>();

    public void ClearRepository()
    {
        Motherboards.Clear();
        Cpus.Clear();
        Bioses.Clear();
        CpuCoolingSystems.Clear();
        RandomAccessMemories.Clear();
        XmpProfiles.Clear();
        VideoCarts.Clear();
        Ssds.Clear();
        Hdds.Clear();
        Corpuses.Clear();
        PowerUnits.Clear();
        WiFiAdapters.Clear();
    }

    public void AddMotherboard(Motherboard motherboard)
    {
        Motherboards.Add(motherboard);
    }

    public void AddCpu(Cpu cpu)
    {
        Cpus.Add(cpu);
    }

    public void AddBios(Bios bios)
    {
        Bioses.Add(bios);
    }

    public void AddXmpProfile(XmpProfile xmpProfile)
    {
        XmpProfiles.Add(xmpProfile);
    }

    public void AddVideoCart(VideoCart videoCart)
    {
        VideoCarts.Add(videoCart);
    }

    public void AddRandomAccessMemory(RAM ram)
    {
        RandomAccessMemories.Add(ram);
    }

    public void AddCpuCoolingSystem(CpuCoolingSystem cpuCoolingSystem)
    {
        CpuCoolingSystems.Add(cpuCoolingSystem);
    }

    public void AddSsd(Ssd ssd)
    {
        Ssds.Add(ssd);
    }

    public void AddHdd(Hdd hdd)
    {
        Hdds.Add(hdd);
    }

    public void AddCorpus(Corpus corpus)
    {
        Corpuses.Add(corpus);
    }

    public void AddPowerUnit(PowerUnit powerUnit)
    {
        PowerUnits.Add(powerUnit);
    }

    public void AddWiFiAdapter(WiFiAdapter wiFiAdapter)
    {
        WiFiAdapters.Add(wiFiAdapter);
    }
}