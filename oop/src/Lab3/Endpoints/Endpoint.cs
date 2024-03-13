using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Endpoints;

public abstract class Endpoint
{
    protected Endpoint(IAddressee addressee, int filter)
    {
        Addressee = addressee;
        Filter = filter;
    }

    protected IAddressee Addressee { get; }
    protected int Filter { get; }
}