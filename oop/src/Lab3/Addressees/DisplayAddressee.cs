using Itmo.ObjectOrientedProgramming.Lab3.Communications;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

// Адресат-дисплей – сообщения для вывода на физическое устровйство отображения.
public class DisplayAddressee : Addressee
{
    public DisplayAddressee(string name)
        : base(name)
    {
    }

    public override void Send(Topic topic, Message message)
    {
        InternalMessaging messaging = InternalMessaging.Instance;
        messaging.Send(this, topic, message);
    }

    public override Message? Receive(int priority)
    {
        InternalMessaging messaging = InternalMessaging.Instance;
        return messaging.Receive(this, priority);
    }
}