using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

// Абстрактый класс адресата с именем для обмена сообщениями.
public abstract class Addressee : IAddressee
{
    protected Addressee(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public abstract void Send(Topic topic, Message message);

    public abstract Message? Receive(int priority);

    public override string ToString()
    {
        return $"{Name}";
    }
}
