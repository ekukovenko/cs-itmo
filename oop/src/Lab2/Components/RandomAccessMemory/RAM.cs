using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class RAM
{
    public RAM(double freeMemoryAmount, IList<JedecVoltageFrequency> jedecVoltageFrequencies, IList<XmpProfile> xmpProfile, string formFactor, string ddr, double powerConsumption)
    {
        FreeMemoryAmount = freeMemoryAmount;
        AvailableJedecVoltageFrequencies = jedecVoltageFrequencies;
        AvailableXmpProfiles = xmpProfile;
        FormFactor = formFactor;
        Ddr = ddr;
        PowerConsumption = powerConsumption;
    }

    public double FreeMemoryAmount { get; }
    public IList<JedecVoltageFrequency> AvailableJedecVoltageFrequencies { get; }
    public IList<XmpProfile> AvailableXmpProfiles { get; }
    public string FormFactor { get; }
    public string Ddr { get; }
    public double PowerConsumption { get; }

    public IRAMBuilder Direct(IRAMBuilder iramBuilder)
    {
        if (iramBuilder is null) throw new ArgumentNullException(nameof(iramBuilder));

        foreach (JedecVoltageFrequency jedecVoltageFrequency in AvailableJedecVoltageFrequencies)
        {
            iramBuilder.AddAvailableJedecVoltageFrequency(jedecVoltageFrequency);
        }

        foreach (XmpProfile xmpProfile in AvailableXmpProfiles)
        {
            iramBuilder.AddXmpProfile(xmpProfile);
        }

        return iramBuilder.WithFreeMemoryAmount(FreeMemoryAmount).WithFormFactor(FormFactor).WithDdrStandard(Ddr).WithPowerConsumption(PowerConsumption);
    }
}