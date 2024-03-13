using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public class Deflector3 : Deflector
{
    public Deflector3(bool isPhotonicShieldActivated)
        : base(40, 10, isPhotonicShieldActivated)
    {
    }

    public override ShipState TakeDamage(Obstacle obstacle)
    {
        return obstacle is ObstacleWhale ? ShipState.DeflectorDestroyed : base.TakeDamage(obstacle);
    }
}