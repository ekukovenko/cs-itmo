using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Stella : Spaceship
{
    public Stella(bool isPhotonicShieldActivated)
        : base(new ImpulseEngineC(), new JumpEngineOmega(), new Deflector1(isPhotonicShieldActivated), new FirstClass(), ShipWeight.Small, true)
    {
    }
}