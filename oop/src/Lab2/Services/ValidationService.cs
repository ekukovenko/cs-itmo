using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Components.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public static class ValidationService
{
    public static ValidationResults PersonalComputerValidation(PersonalComputer personalComputer)
    {
        const double permissibleExcessPowerInWatts = 60;

        // PCIE connections check
        int requiredPciePortsQuantity = 0;
        if (personalComputer != null)
        {
            if (personalComputer.Ssds is not null)
            {
                requiredPciePortsQuantity += personalComputer.Ssds.Count(ssd => ssd.ConnectionType.PcieConnection);
            }

            if (personalComputer.VideoCarts is not null)
            {
                requiredPciePortsQuantity += personalComputer.VideoCarts.Count;
            }

            if (personalComputer.WiFiAdapter is not null)
            {
                requiredPciePortsQuantity += 1;
            }

            if (personalComputer.Motherboard.PcieLinesAmount < requiredPciePortsQuantity)
            {
                return new ValidationResults.ValidationError("Not enough PCIE lines.");
            }

            // SATA connections check
            int requiredSataPortsQuantity = 0;
            if (personalComputer.Ssds is not null)
            {
                requiredSataPortsQuantity += personalComputer.Ssds.Count(ssd => ssd.ConnectionType.SataConnection);
            }

            if (personalComputer.Hdds is not null)
            {
                requiredSataPortsQuantity += personalComputer.Hdds.Count;
            }

            if (personalComputer.Motherboard.SataPortsAmount < requiredSataPortsQuantity)
            {
                if (personalComputer.Ssds is not null)
                {
                    foreach (Ssd ssd in personalComputer.Ssds)
                    {
                        if (ssd.ConnectionType is not { SataConnection: true, PcieConnection: true }) continue;
                        if (!(personalComputer.Motherboard.PcieLinesAmount > requiredPciePortsQuantity)) continue;
                        requiredSataPortsQuantity -= 1;
                        requiredPciePortsQuantity += 1;
                    }
                }

                if (personalComputer.Motherboard.SataPortsAmount < requiredSataPortsQuantity)
                {
                    return new ValidationResults.ValidationError("Not enough SATA ports.");
                }
            }

            // Basic checks
            if ((personalComputer.Motherboard.CpuSocket != personalComputer.Cpu.CpuSocket)
                || (personalComputer.Motherboard.Chipset.XmpProfile != personalComputer.XmpProfile)
                || personalComputer.RandomAccessMemories.Select(randomAccessMemory => randomAccessMemory
                    .AvailableJedecVoltageFrequencies
                    .Any(pair1 => personalComputer.Motherboard.Chipset.AvailableMemoryFrequencies
                        .Any(pair2 => pair1.Jedec == pair2))).Any(hasCommonElements => !hasCommonElements)
                || personalComputer.Motherboard.Bios.Type != personalComputer.Bios.Type
                || personalComputer.Motherboard.Bios.Version != personalComputer.Bios.Version
                || personalComputer.Motherboard.RamTablesAmount < personalComputer.RandomAccessMemories.Count
                || personalComputer.RandomAccessMemories.All(randomAccessMemory =>
                    personalComputer.Motherboard.Ddr != randomAccessMemory.Ddr)
                || (personalComputer.Motherboard.WiFiModule && personalComputer.WiFiAdapter is not null)
                || personalComputer.Bios.SupportedProcessors.All(supportedProcessor =>
                    personalComputer.Cpu != supportedProcessor)
                || (!personalComputer.Cpu.VideoCore && personalComputer.VideoCarts is null))
            {
                return new ValidationResults.ValidationError();
            }

            // Components fit checks
            if (personalComputer.Corpus.SupportedMotherboardFormFactors.All(supportedMotherboardFactor =>
                    personalComputer.Motherboard.FormFactor != supportedMotherboardFactor))
            {
                return new ValidationResults.ValidationError("Motherboard not fits in corpus.");
            }

            if (personalComputer.VideoCarts != null)
            {
                if (personalComputer.VideoCarts.Any(videoCart =>
                        Dimensions.DimensionsComparing(
                            personalComputer.Corpus.MaximumVideoCartDimensions,
                            videoCart.Dimensions)))
                {
                    return new ValidationResults.ValidationError("Video card not fits in corpus.");
                }
            }

            // Power checks
            double requiredPowerAmount = 0;
            requiredPowerAmount += personalComputer.Cpu.PowerConsumption;
            if (personalComputer.VideoCarts is not null)
                requiredPowerAmount += personalComputer.VideoCarts.Sum(videoCart => videoCart.PowerConsumption);
            if (personalComputer.WiFiAdapter != null)
                requiredPowerAmount += personalComputer.WiFiAdapter.PowerConsumption;
            requiredPowerAmount +=
                personalComputer.RandomAccessMemories.Sum(randomAccessMemory => randomAccessMemory.PowerConsumption);
            if (personalComputer.Ssds is not null)
                requiredPowerAmount += personalComputer.Ssds.Sum(ssd => ssd.PowerConsumption);
            if (personalComputer.Hdds is not null)
                requiredPowerAmount += personalComputer.Hdds.Sum(hdd => hdd.PowerConsumption);

            if (personalComputer.PowerUnit.PeakLoad + permissibleExcessPowerInWatts < requiredPowerAmount)
            {
                return new ValidationResults.ValidationError("Insufficient power of the power unit.");
            }

            if (personalComputer.PowerUnit.PeakLoad < requiredPowerAmount &&
                personalComputer.PowerUnit.PeakLoad + permissibleExcessPowerInWatts > requiredPowerAmount)
            {
                return new ValidationResults.SuccessWithWarranty(
                    "The required power slightly exceeds the power of the power unit.");
            }

            // Heat checks
            if (personalComputer.Cpu.Tdp > personalComputer.CpuCoolingSystem.Tdp)
            {
                return new ValidationResults.SuccessWithWarranty(
                    "The amount of heat generated by the processor exceeds the amount dissipated by the cooling system.");
            }
        }

        return new ValidationResults.SuccessValidation();
    }
}