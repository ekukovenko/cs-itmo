using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Communications;
using Itmo.ObjectOrientedProgramming.Lab3.Endpoints;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;
public class Program
{
    private static void VerifyGroupMessaging()
    {
        LogFactory.Get().Info("VerifyGroupMessaging()");

        var address = new GroupAddressee("group");
        address.Add(new UserAddressee("user"));
        address.Add(new MessengerAddressee("messenger"));
        address.Add(new DisplayAddressee("display"));
        var topic = new Topic("test", address);
        var message = new Message("head", "body", 1);
        topic.Send(message);

        InternalMessaging.Instance.Dump();

        var user = new User("user", 2);
        user.Receive();
        var messenger = new Messenger.Messenger("messenger", 2);
        messenger.Receive();
        var display = new Display.Display("display", 2);
        display.Receive();

        InternalMessaging.Instance.Dump();
    }

    private static void VerifyFilteredDisplayMessagingToFile()
    {
        LogFactory.Get().Info("VerifyFilteredDisplayMessagingToFile()");

        LogFactory.Get().Info("Send 3 messages with different priorities");
        var address = new DisplayAddressee("display");
        var topic = new Topic("test", address);
        var message1 = new Message("message", "filtered message", 1);
        var message2 = new Message("message", "filtered message", 2);
        var message3 = new Message("message", "filtered message", 3);
        topic.Send(message1);
        topic.Send(message2);
        topic.Send(message3);

        LogFactory.Get().Info("Create display with file writing");
        var outputFile = new StreamWriter("DisplayMessaging.txt", true);
        outputFile.AutoFlush = true;
        var display = new Display.Display("display", 2, outputFile);

        InternalMessaging.Instance.Dump();

        LogFactory.Get().Info("Receive 1st message with filer 2");
        display.Receive();

        InternalMessaging.Instance.Dump();

        LogFactory.Get().Info("Receive 2nd message with filer 2");
        display.Receive();

        InternalMessaging.Instance.Dump();

        LogFactory.Get().Info("Receive 3rd message with filer 2");
        display.Receive();

        InternalMessaging.Instance.Dump();
    }

    private static void Main(/*string[] args*/)
    {
        Logger logger = new ConsoleLogFactory().Create();
        logger.Info("start");

        VerifyGroupMessaging();
        VerifyFilteredDisplayMessagingToFile();

        logger.Info("stop");
    }
}