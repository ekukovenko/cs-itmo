namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class JedecVoltageFrequency
{
    public JedecVoltageFrequency(double jedec, double voltage)
    {
        Jedec = jedec;
        Voltage = voltage;
    }

    public double Jedec { get; }
    public double Voltage { get; }
}