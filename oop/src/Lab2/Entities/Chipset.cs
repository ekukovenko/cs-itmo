using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Chipset
{
    public Chipset(IReadOnlyCollection<double> availableMemoryFrequencies, XmpProfile xmpProfile, WiFiAdapter wiFiAdapter)
    {
        AvailableMemoryFrequencies = availableMemoryFrequencies;
        XmpProfile = xmpProfile;
        WiFiAdapter = wiFiAdapter;
    }

    public IReadOnlyCollection<double> AvailableMemoryFrequencies { get; }
    public XmpProfile XmpProfile { get; }
    public WiFiAdapter WiFiAdapter { get; set; }
}