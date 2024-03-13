using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

// Интерфейс адресата для отправки и получения сообщений.
public interface IAddressee
{
    public string Name { get; }

    // Передать сообщение адресату
    public void Send(Topic topic, Message message);

    // Получить сообщение адресатом с фильтрацией по уровню важности сообщения
    public Message? Receive(int priority);
}
