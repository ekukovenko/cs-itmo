using Itmo.ObjectOrientedProgramming.Lab3.Communications;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

// Адресат-пользователь – сообщения для пользователя корпоративной системы.
public class UserAddressee : Addressee
{
    public UserAddressee(string name)
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
