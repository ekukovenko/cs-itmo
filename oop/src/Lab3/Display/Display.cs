using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Endpoints;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

// Дисплей:
// - Является конечной точкой сообщения
// - Должен иметь возможность выводить текст лишь одного сообщения заданного цвета
public class Display : Endpoint
{
    private DisplayDriver _driver;

    public Display(string name, int filter, StreamWriter? output = null)
        : base(new DisplayAddressee(name), filter)
    {
        _driver = new DisplayDriver(output);
    }

    public bool Receive()
    {
        Message? message = Addressee.Receive(Filter);

        // Дисплей должен держать лишь одно сообщение, поэтому перед выводом его необходимо очищать
        _driver.Clear();
        if (message != null)
        {
            _driver.SetColor(ConsoleColor.Red);
            _driver.Write(message);
            return true;
        }

        return false;
    }
}
