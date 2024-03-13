namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WiFiAdapter;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder WithWiFiVersion(string wiFiVersion);
    IWiFiAdapterBuilder WithBluetoothModule(bool bluetoothModule);
    IWiFiAdapterBuilder WithPcieVersion(string pcieVersion);
    IWiFiAdapterBuilder WithPowerConsumption(double powerConsumption);
}