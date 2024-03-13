using Lab5.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IHistoryRepository
{
    IAsyncEnumerable<Operation>? CheckHistory(Account account);
    Task SaveHistory(Account account, AccountOperationType operationTypeType, long balanceDiff);
}