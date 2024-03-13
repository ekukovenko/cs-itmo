using Lab5.Models;

namespace Lab5.Application.Contracts.History;

public interface IHistoryService
{
    IAsyncEnumerable<Operation>? CheckHistory(Account account);
}