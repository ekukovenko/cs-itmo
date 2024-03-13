using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public abstract class TreeItem
{
    protected const string Space = "    ";
    protected TreeItem(string name, int level)
    {
        Name = name;
        Level = level;
    }

    protected int Level { get; }
    protected string Name { get; }

    public virtual void Add(TreeItem item) { }

    public virtual void WriteTree(TextWriter stream) { }
}