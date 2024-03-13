namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

// Сообщение
public class Message
{
    public Message(string head, string body, int priority)
    {
        Head = head;
        Body = body;
        Priority = priority;
    }

    // Заголовок
    public string Head { get; }

    // Тело
    public string Body { get; }

    // Уровень важности
    public int Priority { get; }

    public override string ToString()
    {
        return $"<Заголовок='{Head}', Тело='{Body}', УровеньВажности={Priority}>";
    }
}
