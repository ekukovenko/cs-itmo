using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public abstract class FilesystemState
{
    public abstract void Execute(FilesystemCommand command, string[] arguments, FilesystemContext context);

    protected static bool PathExists(string path)
    {
        bool exists = Directory.Exists(path);
        LogFactory.Get().Info($"FilesystemState.PathExists({path}) = {exists}");
        return exists;
    }

    protected static bool FileExists(string file)
    {
        bool exists = File.Exists(file);
        LogFactory.Get().Info($"FilesystemState.FileExists({file}) = {exists}");
        return exists;
    }
}