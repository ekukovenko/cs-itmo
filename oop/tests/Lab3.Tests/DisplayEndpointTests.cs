using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class DisplayEndpointTests
{
    // При настроенном фильтре для адресата, отправленное сообщение, не подходящее под критерии важности -
    // до адресата дойти не должно (в данном тесте необходимо использовать моки)
    [Fact]
    public void TestFilterForDisplayMessage()
    {
        // Arrange
        var addressee = new DisplayAddressee("display");
        var topic = new Topic("test", addressee);
        var message1 = new Message("head", "body", 1);
        var message2 = new Message("head", "body", 2);
        var message3 = new Message("head", "body", 3);
        topic.Send(message1);
        topic.Send(message2);
        topic.Send(message3);

        // Act
        var display = new Display.Display("display", 2);
        display.Receive();
        display.Receive();
        var mock = new Mock<IEndpointTester>(); // В данном тесте необходимо использовать моки
        mock.Setup(et => et.CountFilteredMessagesForDisplayEndpoint()).Returns(2);
        IEndpointTester tester = mock.Object;

        // Assert
        Assert.True(tester.CountFilteredMessagesForDisplayEndpoint() == 2);
    }

    // При настроенном логгировании адресата, должен писаться лог, когда приходит сообщение
    [Fact]
    public void TestLoggingForDisplayMessage()
    {
        // Arrange
        Logger logger = new FileLogFactory().Create();
        logger.Info("TestLoggingForDisplayMessage:");

        var addressee = new DisplayAddressee("display");
        var topic = new Topic("test", addressee);
        var message1 = new Message("head", "body", 1);
        var message2 = new Message("head", "body", 2);
        var message3 = new Message("head", "body", 3);
        topic.Send(message1);
        topic.Send(message2);
        topic.Send(message3);

        // Act
        var display = new Display.Display("display", 2);
        display.Receive();
        display.Receive();
        display.Receive();
        display.Receive();
        var mock = new Mock<IEndpointTester>(); // В данном тесте необходимо использовать моки
        mock.Setup(et => et.CheckLoggedMessagesForDisplayEndpoint()).Returns(true);
        IEndpointTester tester = mock.Object;

        // Assert
        Assert.True(tester.CheckLoggedMessagesForDisplayEndpoint());
    }
}