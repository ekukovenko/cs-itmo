using Itmo.ObjectOrientedProgramming.Lab1.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.StrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceship;

public abstract class Spaceship
{
    protected Spaceship(ImpulseEngine? impulseEngine, JumpEngine? jumpEngine, Deflector.Deflector? deflector, StrengthClassDefault strengthClass, ShipWeight shipWeight, bool antiNeutrinoEmitter)
    {
        ImpulseEngine = impulseEngine;
        JumpEngine = jumpEngine;
        DefaultDeflector = deflector;
        StrengthClassDefault = strengthClass;
        ShipWeight = shipWeight;
        AntiNeutrinoEmitter = antiNeutrinoEmitter;
    }

    public ImpulseEngine? ImpulseEngine { get; }
    public JumpEngine? JumpEngine { get; }

    public Deflector.Deflector? DefaultDeflector { get; }

    public StrengthClassDefault StrengthClassDefault { get; }

    public ShipWeight ShipWeight { get; }

    public bool AntiNeutrinoEmitter { get; }
}