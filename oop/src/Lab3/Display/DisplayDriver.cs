using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Display;

// Дисплей-драйвер:
// - Должен иметь возможность очистить вывод
// - Должен иметь возможность задать цвет выводимого текста
// - Должен иметь возможность записать текст
public class DisplayDriver
{
    private ConsoleColor _color = ConsoleColor.Black;
    private StreamWriter? _output;

    public DisplayDriver(StreamWriter? output = null)
    {
        _output = output;
    }

    // Очистить экран
    public void Clear()
    {
        if (_output == null)
            Console.Clear();
    }

    // Задать цвет выводимого текста
    public void SetColor(ConsoleColor color)
    {
        _color = color;
    }

    // Записать текст на экране
    public void Write(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (_output == null)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
        else
        {
            _output.WriteLine($"{message}");
        }
    }
}
