namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Dimensions
{
    private double height;
    private double lenght;

    public Dimensions(double height, double lenght)
    {
        this.height = height;
        this.lenght = lenght;
    }

    public static bool DimensionsComparing(Dimensions dimensionOne, Dimensions dimensionTwo)
    {
        return dimensionOne?.height == dimensionTwo?.height && dimensionOne?.lenght == dimensionTwo?.lenght;
    }
}