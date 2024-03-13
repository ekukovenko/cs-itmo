using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public class WiFiAdapterBuilder : IWiFiAdapterBuilder
{
    private string? _wiFiVersion;
    private bool _bluetoothModule;
    private string? _pcieVersion;
    private double _powerConsumption;

    public IWiFiAdapterBuilder WithWiFiVersion(string wiFiVersion)
    {
        _wiFiVersion = wiFiVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithBluetoothModule(bool bluetoothModule)
    {
        _bluetoothModule = bluetoothModule;
        return this;
    }

    public IWiFiAdapterBuilder WithPcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public IWiFiAdapterBuilder WithPowerConsumption(double powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _wiFiVersion ?? throw new ArgumentNullException(nameof(_wiFiVersion)),
            _bluetoothModule,
            _pcieVersion ?? throw new ArgumentNullException(nameof(_wiFiVersion)),
            _powerConsumption);
    }
}