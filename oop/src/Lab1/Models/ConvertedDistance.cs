using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public static class ConvertedDistance
{
    public static int ConvertDistance(this DistanceOfPathSegment distance)
    {
        return distance switch
        {
            DistanceOfPathSegment.Small => 100,
            DistanceOfPathSegment.Medium => 200,
            DistanceOfPathSegment.Big => 300,
            _ => throw new ArgumentOutOfRangeException(nameof(distance), distance, null),
        };
    }
}