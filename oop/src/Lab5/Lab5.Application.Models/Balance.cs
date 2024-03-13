namespace Lab5.Models;

public record Balance
{
    public Balance(long value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Balance can't be negative", nameof(value));
        }

        Value = value;
    }

    public long Value { get; }
}