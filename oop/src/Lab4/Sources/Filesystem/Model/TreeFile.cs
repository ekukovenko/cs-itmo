using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public class TreeFile : TreeItem
{
    private const string Icon = "-";
    public TreeFile(string name, int level)
        : base(name, level)
    {
        LogFactory.Get().Info($"TreeFile({name})");
    }

    public override void WriteTree(TextWriter? stream)
    {
        string space = string.Empty;
        for (int i = 0; i < Level; i++) space += Space;
        if (stream != null)
            stream.Write($"{space} {Icon} {Name}\n");
        else
            throw new ArgumentNullException(nameof(stream));
    }
}