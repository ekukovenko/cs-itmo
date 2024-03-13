using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Endpoints;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class UserEndpointTests
{
    // При получении сообщения пользователем, оно сохраняется в статусе “не прочитано”.
    [Fact]
    public void TestUnreadStatusForReceivedMessage()
    {
        // Arrange
        var addressee = new UserAddressee("user");
        var topic = new Topic("test", addressee);
        var message = new Message("head", "body", 1);
        topic.Send(message);

        // Act
        var user = new User("user", 3);
        user.Receive();

        // Assert
        Assert.True(user.Status == User.EStatus.Unread);
    }

    // При попытке отметить сообщение пользователя в статусе “не прочитано” как прочитанное,
    // оно должно поменять свой статус.
    [Fact]
    public void TestReadStatusForUnreadMessage()
    {
        // Arrange
        var addressee = new UserAddressee("user");
        var topic = new Topic("test", addressee);
        var message = new Message("head", "body", 1);
        topic.Send(message);

        // Act
        var user = new User("user", 3);
        bool isReceived = user.Receive();
        bool isRead = user.MarkAsRead();

        // Assert
        Assert.True(isReceived && isRead && user.Status == User.EStatus.Read);
    }

    // При попытке отметить сообщение пользователя в статусе “прочитано” как прочитанное,
    // должна вернуться ошибка.
    [Fact]
    public void TestErrorToMarkAsReadForReadMessage()
    {
        // Arrange
        var addressee = new UserAddressee("user");
        var topic = new Topic("test", addressee);
        var message = new Message("head", "body", 1);
        topic.Send(message);

        // Act
        var user = new User("user", 3);
        bool isReceived = user.Receive();
        bool isRead1 = user.MarkAsRead();
        bool isRead2 = user.MarkAsRead();

        // Assert
        Assert.True(isReceived && isRead1 && !isRead2);
    }
}