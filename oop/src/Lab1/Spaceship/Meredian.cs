using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Meredian : Spaceship
{
    public Meredian(bool isPhotonicShieldActivated)
        : base(new ImpulseEngineE(), null, new Deflector2(isPhotonicShieldActivated), new SecondClass(), ShipWeight.Medium, true)
    {
    }
}