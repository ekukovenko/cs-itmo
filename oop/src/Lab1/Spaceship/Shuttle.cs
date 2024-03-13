using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Shuttle : Spaceship
{
    public Shuttle()
    : base(new ImpulseEngineC(), null, null, new FirstClass(), ShipWeight.Small, false)
    {
    }
}