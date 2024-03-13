using Itmo.ObjectOrientedProgramming.Lab3.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

// Топик
public class Topic
{
    // Конструктор
    public Topic(string title, IAddressee addressee)
    {
        Title = title;
        Addressee = addressee;
    }

    // Адресат
    public IAddressee Addressee { get; }

    // Название
    public string Title { get; }

    // Отправить сообщение адресату
    public void Send(Message message)
    {
        Addressee.Send(this, message);
    }
}
