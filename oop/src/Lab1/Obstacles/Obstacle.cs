namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacles;

public abstract class Obstacle
{
    protected Obstacle(double damage, bool crewKill)
    {
        Damage = damage;
        CrewKill = crewKill;
    }

    public bool CrewKill { get; }
    public double Damage { get; }
}