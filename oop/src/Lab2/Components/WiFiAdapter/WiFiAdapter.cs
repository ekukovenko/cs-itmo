using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public class WiFiAdapter
{
    public WiFiAdapter(string wiFiVersion, bool bluetoothModule, string pcieVersion, double powerConsumption)
    {
        WiFiVersion = wiFiVersion;
        BluetoothModule = bluetoothModule;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
    }

    public string WiFiVersion { get; }
    public bool BluetoothModule { get; }
    public string PcieVersion { get; }
    public double PowerConsumption { get; }

    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder wiFiAdapterBuilder)
    {
        if (wiFiAdapterBuilder is null) throw new ArgumentNullException(nameof(wiFiAdapterBuilder));

        return wiFiAdapterBuilder.WithWiFiVersion(WiFiVersion).WithPcieVersion(PcieVersion).WithBluetoothModule(BluetoothModule).WithPowerConsumption(PowerConsumption);
    }
}