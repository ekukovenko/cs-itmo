using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;

public class FilesystemContext
{
    private string _absDir = string.Empty;
    public FilesystemContext(bool verbose = true)
    {
        State = new FilesystemDisconnected();
        Verbose = verbose;
    }

    public FilesystemState State { get; set; }
    public string RelDir { get; set; } = string.Empty;
    public string AbsDir
    {
        get => _absDir;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value.Length > 0 && value[value.Length - 1] == Path.DirectorySeparatorChar)
                _absDir = value;
            else
                _absDir = value + Path.DirectorySeparatorChar;
        }
    }

    protected bool Verbose { get; }

    public void Connect(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.Connect, arguments, this);
        if (Verbose) Dump("after");
    }

    public void Disconnect(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.Disconnect, arguments, this);
        if (Verbose) Dump("after");
    }

    public void GotoTree(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.GotoTree, arguments, this);
        if (Verbose) Dump("after");
    }

    public void ListTree(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.ListTree, arguments, this);
        if (Verbose) Dump("after");
    }

    public void ShowFile(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.ShowFile, arguments, this);
        if (Verbose) Dump("after");
    }

    public void MoveFile(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.MoveFile, arguments, this);
        if (Verbose) Dump("after");
    }

    public void CopyFile(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.CopyFile, arguments, this);
        if (Verbose) Dump("after");
    }

    public void DeleteFile(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.DeleteFile, arguments, this);
        if (Verbose) Dump("after");
    }

    public void RenameFile(string[] arguments)
    {
        if (Verbose) Dump("before");
        State.Execute(FilesystemCommand.RenameFile, arguments, this);
        if (Verbose) Dump("after");
    }

    private void Dump(string prefix = "")
    {
        LogFactory.Get().Info($"FilesystemContext.Dump({prefix}) State={State.GetType().Name}, AbsDir='{AbsDir}', RelDir='{RelDir}'");
    }
}