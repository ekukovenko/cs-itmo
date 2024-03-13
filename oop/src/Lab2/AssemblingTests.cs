using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Corpus;
using Itmo.ObjectOrientedProgramming.Lab2.Components.PowerUnit;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Components.VideoCart;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class AssemblingTests
{
    [Fact]
    public void AssemblingCompatibleAccessoriesBuildPCSuccess()
    {
        // Arrange
        Repository repository = Repository.Instance;

        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen7 = new Cpu("AMD Ryzen 7 5800X", 3.8, 8, "AM4", false, new List<double> { 3200, 3600, 3800, 4000, 4400 }, 105, 105);
        var intelCoreI7 = new Cpu("Intel Core i7-11700K", 3.6, 8, "AM4", true, new List<double> { 2666, 2933, 3200, 3600, 4000 }, 125, 250);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCoreI7, amdRyzen7 });
        var msiB550Tomahawk = new Motherboard("AM4", 20, 6, chipset, "DDR4", 4, "ATX", bios, true);
        var samsung970EvoPlusNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3070 = new VideoCart(new Dimensions(10.5, 4.2), 8.0, "PCIe 4.0", 1500, 250.0);
        var evgaSuperNOVA650G5 = new PowerUnit(650);
        var noctuaNHU12S = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510iAtxMidTower = new Corpus(new Dimensions(42.8, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(49.0, 43.4));
        var corsairVengeanceRgbPro = new RAM(32.0, new List<JedecVoltageFrequency> { new JedecVoltageFrequency(2666, 1.2), new JedecVoltageFrequency(3200, 1.35), }, new List<XmpProfile> { new XmpProfile("16", 16, 3200), new XmpProfile("18", 18, 2666), }, "DIMM", "DDR4", 1.35);
        repository.Motherboards.Add(msiB550Tomahawk);
        repository.Cpus.Add(intelCoreI7);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(noctuaNHU12S);
        repository.RandomAccessMemories.Add(corsairVengeanceRgbPro);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3070);
        repository.Ssds.Add(samsung970EvoPlusNVMe);
        repository.Corpuses.Add(nzxtH510iAtxMidTower);
        repository.PowerUnits.Add(evgaSuperNOVA650G5);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510iAtxMidTower))
            .WithPowerUnit(repository.PowerUnits.FirstOrDefault(evgaSuperNOVA650G5))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile))
            .WithCpu(repository.Cpus.FirstOrDefault(intelCoreI7))
            .AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoPlusNVMe))
            .WithMotherboard(repository.Motherboards.FirstOrDefault(msiB550Tomahawk))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault())
            .AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(corsairVengeanceRgbPro))
            .WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(noctuaNHU12S));

        // Act
        PersonalComputerBuildResult result = personalComputerBuilder.Build();
        repository.ClearRepository();

        // Assert
        Assert.IsType<PersonalComputerBuildResult.Success>(result);
    }

    [Fact]
    public void AssemblingHigherPowerConsumingBuildPCSuccessWithWarranty()
    {
        // Arrange
        Repository repository = Repository.Instance;

        int testConsumptionForVideoCart = 400;
        int testPowerConsumptionForCpu = 250;
        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen7 = new Cpu("AMD Ryzen 7 5800X", 3.8, 8, "AM4", false, new List<double> { 3200, 3600, 3800, 4000, 4400 }, 105, 105);
        var intelCoreI7 = new Cpu("Intel Core i7-11700K", 3.6, 8, "AM4", true, new List<double> { 2666, 2933, 3200, 3600, 4000 }, 125, testPowerConsumptionForCpu);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCoreI7, amdRyzen7 });
        var msiB550Tomahawk = new Motherboard("AM4", 20, 6, chipset, "DDR4", 4, "ATX", bios, true);
        var samsung970EvoPlusNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3070 = new VideoCart(new Dimensions(10.5, 4.2), 8.0, "PCIe 4.0", 1500, testConsumptionForVideoCart);
        var evgaSuperNOVA650G5 = new PowerUnit(650);
        var noctuaNHU12S = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510iAtxMidTower = new Corpus(new Dimensions(42.8, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(49.0, 43.4));
        var corsairVengeanceRgbPro = new RAM(32.0, new List<JedecVoltageFrequency> { new JedecVoltageFrequency(2666, 1.2), new JedecVoltageFrequency(3200, 1.35), }, new List<XmpProfile> { new XmpProfile("16", 16, 3200), new XmpProfile("18", 18, 2666), }, "DIMM", "DDR4", 1.35);
        repository.Motherboards.Add(msiB550Tomahawk);
        repository.Cpus.Add(intelCoreI7);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(noctuaNHU12S);
        repository.RandomAccessMemories.Add(corsairVengeanceRgbPro);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3070);
        repository.Ssds.Add(samsung970EvoPlusNVMe);
        repository.Corpuses.Add(nzxtH510iAtxMidTower);
        repository.PowerUnits.Add(evgaSuperNOVA650G5);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510iAtxMidTower))
            .WithPowerUnit(repository.PowerUnits.FirstOrDefault(evgaSuperNOVA650G5))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile))
            .WithCpu(repository.Cpus.FirstOrDefault(intelCoreI7))
            .AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoPlusNVMe))
            .WithMotherboard(repository.Motherboards.FirstOrDefault(msiB550Tomahawk))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault())
            .AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(corsairVengeanceRgbPro))
            .WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(noctuaNHU12S));

        // Act
        PersonalComputerBuildResult result = personalComputerBuilder.Build();
        repository.ClearRepository();

        // Assert
        Assert.IsType<PersonalComputerBuildResult.SuccessWithWarrantyDisclaimer>(result);
    }

    [Fact]
    public void AssemblingHigherHeatGeneratingBuildPCSuccessWithWarranty()
    {
        // Arrange
        Repository repository = Repository.Instance;

        int testConsumptionForVideoCart = 400;
        int testPowerConsumptionForCpu = 250;
        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen7 = new Cpu("AMD Ryzen 7 5800X", 3.8, 8, "AM4", false, new List<double> { 3200, 3600, 3800, 4000, 4400 }, 105, 105);
        var intelCoreI7 = new Cpu("Intel Core i7-11700K", 3.6, 8, "AM4", true, new List<double> { 2666, 2933, 3200, 3600, 4000 }, 125, testPowerConsumptionForCpu);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCoreI7, amdRyzen7 });
        var msiB550Tomahawk = new Motherboard("AM4", 20, 6, chipset, "DDR4", 4, "ATX", bios, true);
        var samsung970EvoPlusNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3070 = new VideoCart(new Dimensions(10.5, 4.2), 8.0, "PCIe 4.0", 1500, testConsumptionForVideoCart);
        var evgaSuperNOVA650G5 = new PowerUnit(650);
        var noctuaNHU12S = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510iAtxMidTower = new Corpus(new Dimensions(42.8, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(49.0, 43.4));
        var corsairVengeanceRgbPro = new RAM(32.0, new List<JedecVoltageFrequency> { new JedecVoltageFrequency(2666, 1.2), new JedecVoltageFrequency(3200, 1.35), }, new List<XmpProfile> { new XmpProfile("16", 16, 3200), new XmpProfile("18", 18, 2666), }, "DIMM", "DDR4", 1.35);
        repository.Motherboards.Add(msiB550Tomahawk);
        repository.Cpus.Add(intelCoreI7);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(noctuaNHU12S);
        repository.RandomAccessMemories.Add(corsairVengeanceRgbPro);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3070);
        repository.Ssds.Add(samsung970EvoPlusNVMe);
        repository.Corpuses.Add(nzxtH510iAtxMidTower);
        repository.PowerUnits.Add(evgaSuperNOVA650G5);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510iAtxMidTower))
            .WithPowerUnit(repository.PowerUnits.FirstOrDefault(evgaSuperNOVA650G5))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile))
            .WithCpu(repository.Cpus.FirstOrDefault(intelCoreI7))
            .AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoPlusNVMe))
            .WithMotherboard(repository.Motherboards.FirstOrDefault(msiB550Tomahawk))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault())
            .AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(corsairVengeanceRgbPro))
            .WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(noctuaNHU12S));

        // Act
        PersonalComputerBuildResult result = personalComputerBuilder.Build();
        repository.ClearRepository();

        // Assert
        Assert.IsType<PersonalComputerBuildResult.SuccessWithWarrantyDisclaimer>(result);
    }

    [Fact]
    public void AssemblingLessPCIELinesBuildPCErrorWithMessage()
    {
        Repository repository = Repository.Instance;

        int testConsumptionForVideoCart = 400;
        int testPowerConsumptionForCpu = 250;
        var xmpProfile = new XmpProfile("16", 1.35, 3200);
        var chipsetMemoryFrequencies = new List<double> { 2133, 2400, 2666, 2933, 3200, 3600, 4000 };
        var wiFiAdapter = new WiFiAdapter("Wi-Fi 6E", true, "PCIe 4.0", 5);
        var chipset = new Chipset(chipsetMemoryFrequencies, xmpProfile, wiFiAdapter);
        var amdRyzen7 = new Cpu("AMD Ryzen 7 5800X", 3.8, 8, "AM4", false, new List<double> { 3200, 3600, 3800, 4000, 4400 }, 105, 105);
        var intelCoreI7 = new Cpu("Intel Core i7-11700K", 3.6, 8, "AM4", true, new List<double> { 2666, 2933, 3200, 3600, 4000 }, 125, testPowerConsumptionForCpu);
        var bios = new Bios("UEFI", "v2.1", new List<Cpu> { intelCoreI7, amdRyzen7 });
        var msiB550Tomahawk = new Motherboard("AM4", 1, 1, chipset, "DDR4", 4, "ATX", bios, true);
        var samsung970EvoPlusNVMe = new Ssd(new SsdConnectionType() { PcieConnection = true, SataConnection = false }, 1000, 3500, 6);
        var nvidiaGeForceRTX3070 = new VideoCart(new Dimensions(10.5, 4.2), 8.0, "PCIe 4.0", 1500, testConsumptionForVideoCart);
        var evgaSuperNOVA650G5 = new PowerUnit(650);
        var noctuaNHU12S = new CpuCoolingSystem(new Dimensions(16.7, 16.5), new List<string> { "LGA1151", "AM4", "LGA1200", "LGA2066", "AM3+", "FM2+" }, 165.0);
        var nzxtH510iAtxMidTower = new Corpus(new Dimensions(42.8, 21.0), new List<string> { "ATX", "Micro-ATX", "Mini-ITX" }, new Dimensions(49.0, 43.4));
        var corsairVengeanceRgbPro = new RAM(32.0, new List<JedecVoltageFrequency> { new JedecVoltageFrequency(2666, 1.2), new JedecVoltageFrequency(3200, 1.35), }, new List<XmpProfile> { new XmpProfile("16", 16, 3200), new XmpProfile("18", 18, 2666), }, "DIMM", "DDR4", 1.35);
        repository.Motherboards.Add(msiB550Tomahawk);
        repository.Cpus.Add(intelCoreI7);
        repository.Bioses.Add(bios);
        repository.CpuCoolingSystems.Add(noctuaNHU12S);
        repository.RandomAccessMemories.Add(corsairVengeanceRgbPro);
        repository.XmpProfiles.Add(xmpProfile);
        repository.VideoCarts.Add(nvidiaGeForceRTX3070);
        repository.Ssds.Add(samsung970EvoPlusNVMe);
        repository.Corpuses.Add(nzxtH510iAtxMidTower);
        repository.PowerUnits.Add(evgaSuperNOVA650G5);
        IPersonalComputerBuilder personalComputerBuilder = new PersonalComputerBuilder().WithBios(repository.Bioses.FirstOrDefault(bios))
            .WithCorpus(repository.Corpuses.FirstOrDefault(nzxtH510iAtxMidTower))
            .WithPowerUnit(repository.PowerUnits.FirstOrDefault(evgaSuperNOVA650G5))
            .WithXmpProfile(repository.XmpProfiles.FirstOrDefault(xmpProfile))
            .WithCpu(repository.Cpus.FirstOrDefault(intelCoreI7))
            .AddSsd(repository.Ssds.FirstOrDefault(samsung970EvoPlusNVMe))
            .WithMotherboard(repository.Motherboards.FirstOrDefault(msiB550Tomahawk))
            .AddVideoCart(repository.VideoCarts.FirstOrDefault())
            .AddRandomAccessMemory(repository.RandomAccessMemories.FirstOrDefault(corsairVengeanceRgbPro))
            .WithCpuCoolingSystem(repository.CpuCoolingSystems.FirstOrDefault(noctuaNHU12S));

        // Act
        PersonalComputerBuildResult result = personalComputerBuilder.Build();
        string factMessage = result.Comment;
        string expectedMessage = "Not enough PCIE lines.";
        repository.ClearRepository();

        // Assert
        Assert.Equal(expectedMessage, factMessage);
    }
}