using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Vaclas : Spaceship
{
    public Vaclas(bool isPhotonicShieldActivated)
        : base(new ImpulseEngineE(), new JumpEngineGamma(), new Deflector1(isPhotonicShieldActivated), new FirstClass(), ShipWeight.Medium, false)
    {
    }
}