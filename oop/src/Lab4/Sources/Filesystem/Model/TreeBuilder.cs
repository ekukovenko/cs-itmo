using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public static class TreeBuilder
{
    public static TreeItem Build(string rootPath, int depth = -1)
    {
        LogFactory.Get().Info($"TreeBuilder.Build({rootPath}, {depth})");

        var rootDirectory = new DirectoryInfo(rootPath);
        TreeItem treeItem = Create(rootDirectory, 0, depth);
        return treeItem;
    }

    private static TreeItem Create(DirectoryInfo directory, int level, int depth)
    {
        LogFactory.Get().Info($"TreeBuilder.Create({directory.Name}, {level}, {depth})");

        TreeItem treeItem = new TreeDirectory(directory.Name, level);
        if (depth >= 0 && level > depth) return treeItem;
        try
        {
            foreach (DirectoryInfo subdirectory in directory.GetDirectories())
            {
                treeItem.Add(Create(subdirectory, level + 1, depth));
            }

            foreach (FileInfo file in directory.GetFiles())
            {
                treeItem.Add(new TreeFile(file.Name, level + 1));
            }
        }
        catch (UnauthorizedAccessException e)
        {
            LogFactory.Get().Warning($"DirectoryBuilder.Create(): {e}");
        }

        return treeItem;
    }
}