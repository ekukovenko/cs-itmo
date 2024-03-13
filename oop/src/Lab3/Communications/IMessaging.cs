using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Communications;

// Интерфейс сервиса обмена сообщениями.
internal interface IMessaging
{
    void Send(IAddressee addressee, Topic topic, Message message);
    Message? Receive(Addressee addressee, int priority);
    void Dump();
}