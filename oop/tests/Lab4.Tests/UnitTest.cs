using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Filesystem.Model;
using Itmo.ObjectOrientedProgramming.Lab4.Sources.Logging;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class UnitTest
{
    [Fact]
    public void ValidCommandParser()
    {
        // Arrange
        Logger logger = new ConsoleLogFactory().Create();

        // Act
        logger.Info("Act");
        var commands = new Dictionary<string, bool>()
        {
            { "абра-кадабра", false },
            { "help", true },
            { "Connect", false },
            { "connect", true },
            { "disconnect", true },
            { "tree", true },
            { "file", true },
            { "exit", true },
        };

        // Assert
        logger.Info("Assert");
        foreach (string command in commands.Keys)
        {
            bool result = CommandFacade.Contains(command);
            Assert.Equal(result, commands[command]);
        }
    }
}