using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Communications;

// Реализация сервиса обмена сообщениями внутри приложения.
public class InternalMessaging : IMessaging
{
    private static InternalMessaging? _instance;
    private readonly List<Package>? _packages;

    private InternalMessaging(List<Package> packages)
    {
        _packages = packages;
    }

    public static InternalMessaging Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InternalMessaging(new List<Package>());
            }

            return _instance;
        }
    }

    public void Send(IAddressee addressee, Topic topic, Message message)
    {
        InternalMessaging instance = InternalMessaging.Instance;
        ArgumentNullException.ThrowIfNull(topic);
        instance._packages?.Add(new Package(addressee, topic, message));
    }

    public Message? Receive(Addressee addressee, int priority)
    {
        InternalMessaging instance = InternalMessaging.Instance;
        Package? package = instance._packages?.Find(x => x.TheAddressee.Name == addressee.Name);
        if (package != null)
        {
            instance._packages?.Remove(package);
            if (package.TheMessage.Priority <= priority)
                return package.TheMessage;
        }

        return null;
    }

    public void Dump()
    {
        Logger logger = LogFactory.Get();
        InternalMessaging instance = InternalMessaging.Instance;
        if (instance._packages != null)
        {
            logger.Info($"Dump() Count={instance._packages.Count}:");
            foreach (Package pkg in instance._packages)
            {
                string line =
                    $"\t{pkg.TheTopic.Title}: {pkg.TheTopic.Addressee.Name}/{pkg.TheAddressee.Name} – <{pkg.TheMessage.Head}/{pkg.TheMessage.Body}/{pkg.TheMessage.Priority}>";
                logger.Info(line);
            }
        }
        else
        {
            logger.Warning($"Dump() ???");
        }
    }

    private class Package
    {
        public Package(IAddressee addressee, Topic topic, Message message)
        {
            TheAddressee = addressee;
            TheTopic = topic;
            TheMessage = message;
        }

        public IAddressee TheAddressee { get; }
        public Topic TheTopic { get; }
        public Message TheMessage { get; }
    }
}
