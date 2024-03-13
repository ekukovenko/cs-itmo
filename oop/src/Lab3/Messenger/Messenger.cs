using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Endpoints;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messenger;

// Мессенджер:
// - Является конечной точкой сообщения
// - Должен иметь возможность выводить текст в консоль с припиской “мессенджер”
public class Messenger : Endpoint
{
    private const string Prefix = "Mессенджер";

    public Messenger(string name, int filter)
        : base(new MessengerAddressee(name), filter)
    {
    }

    public bool Receive()
    {
        Message? message = Addressee.Receive(Filter);
        if (message != null)
        {
            string line = $"{Prefix}: {Addressee} - {message}";
            Console.WriteLine(line);
            return true;
        }

        return false;
    }
}
