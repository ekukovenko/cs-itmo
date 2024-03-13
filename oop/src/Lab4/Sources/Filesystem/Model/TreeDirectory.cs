using System;
using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public class TreeDirectory : TreeItem
{
    private const string Icon = "+";

    public TreeDirectory(string name, int level)
        : base(name, level)
    {
        Items = new List<TreeItem>();
        LogFactory.Get().Info($"TreeDirectory({name})");
    }

    private List<TreeItem> Items { get; }

    public override void Add(TreeItem item)
    {
        Items.Add(item);
    }

    public override void WriteTree(TextWriter? stream)
    {
        string space = string.Empty;
        for (int i = 0; i < Level; i++) space += Space;
        if (stream != null)
        {
            stream.Write($"{space} {Icon} {Name}\n");
            foreach (TreeItem item in Items)
            {
                item.WriteTree(stream);
            }
        }
        else
        {
            throw new ArgumentNullException(nameof(stream));
        }
    }
}