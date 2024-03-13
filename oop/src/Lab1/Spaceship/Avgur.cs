using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public class Avgur : Spaceship
{
    public Avgur(bool isPhotonicShieldActivated)
        : base(new ImpulseEngineE(), new JumpEngineAlpha(), new Deflector3(isPhotonicShieldActivated), new ThirdClass(), ShipWeight.Big, false)
    {
    }
}