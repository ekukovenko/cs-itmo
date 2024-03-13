namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public interface IEndpointTester
{
    int CountFilteredMessagesForDisplayEndpoint();
    bool CheckLoggedMessagesForDisplayEndpoint();
    bool CheckReceivedMessageForMessengerEndpoint();
}