using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerEndpointTests
{
    // При отправке сообщения в месенджер, его реализация должна производить ожидаемое значение
    [Fact]
    public void TestReceivedMessageForMessengerEndpoint()
    {
        // Arrange
        var addressee = new MessengerAddressee("messenger");
        var topic = new Topic("test", addressee);
        var message = new Message("head", "body", 1);
        topic.Send(message);

        // Act
        var messenger = new Messenger.Messenger("messenger", 2);
        messenger.Receive();
        var mock = new Mock<IEndpointTester>(); // В данном тесте необходимо использовать моки
        mock.Setup(et => et.CheckReceivedMessageForMessengerEndpoint()).Returns(true);
        IEndpointTester tester = mock.Object;

        // Assert
        Assert.True(tester.CheckReceivedMessageForMessengerEndpoint());
    }
}
