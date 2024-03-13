using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Endpoints;

// Пользователь:
// - Является конечной точкой сообщения
// - Пользователь может иметь некоторые атрибуты (не обязательно для контекста лабораторной)
// - Должна быть возможность отправить пользователю сообщение
// - Пользователь должен отслеживать полученные сообщения, и их статус (прочитано, не прочитано)
// - Пользователь должен иметь возможность отметить сообщение прочитанным
public class User : Endpoint
{
    private Message? _lastMessage;
    private EStatus _messageStatus; // статус сообщения существует только в контексте пользователя

    public User(string name, int filter)
        : base(new UserAddressee(name), filter)
    {
        _lastMessage = null;
        _messageStatus = EStatus.Empty;
    }

    public enum EStatus
    {
        Empty,
        Unread,
        Read,
    }

    public EStatus Status => _messageStatus;

    // Получить отправленное пользователю сообщение
    public bool Receive()
    {
        _lastMessage = Addressee.Receive(Filter);
        if (_lastMessage != null)
        {
            string line = $"{Addressee} - {_lastMessage}";
            Console.WriteLine(line);
            _messageStatus = EStatus.Unread;
        }

        return _messageStatus == EStatus.Unread;
    }

    // Отметить полученное сообщение как прочитанное
    // Отметка должна быть возможно только для непрочитанных сообщений,
    // попытка отметить ранее прочитанное сообщение должно возвращать ошибку
    public bool MarkAsRead()
    {
        if (_lastMessage != null && _messageStatus == EStatus.Unread)
        {
            _messageStatus = EStatus.Read;
            return true;
        }

        return false;
    }
}
