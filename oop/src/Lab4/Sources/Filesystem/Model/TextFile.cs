using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.View;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public class TextFile
{
    public TextFile(string name)
    {
        Name = name;
    }

    private string Name { get; }
    public void WriteContent(TextWriter stream)
    {
        ArgumentNullException.ThrowIfNull(stream);
        try
        {
            string text = File.ReadAllText(Name);
            stream.Write(text);
        }
        catch (IOException e)
        {
            Display.Exception(e);
        }
    }
}