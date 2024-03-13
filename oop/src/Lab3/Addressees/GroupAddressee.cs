using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

// Адесат-группа – сообщения для нескольких адресатов.
public class GroupAddressee : Addressee
{
    private readonly List<IAddressee> _addresses = new List<IAddressee>();
    public GroupAddressee(string name)
        : base(name)
    {
    }

    public void Add(IAddressee addressee)
    {
        _addresses.Add(addressee);
    }

    public override void Send(Topic topic, Message message)
    {
        foreach (IAddressee addressee in _addresses)
        {
            addressee.Send(topic, message);
        }
    }

    public override Message? Receive(int priority)
    {
        // Сообщение никогда не поступит на адресат группы
        return null;
    }
}
