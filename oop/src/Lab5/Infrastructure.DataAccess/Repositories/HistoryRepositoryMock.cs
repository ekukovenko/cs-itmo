using Lab5.Application.Abstractions.Repositories;
using Lab5.Models;

namespace Infrastructure.DataAccess.Repositories;

public class HistoryRepositoryMock : IHistoryRepository
{
    public IAsyncEnumerable<Operation>? CheckHistory(Account account)
    {
        return null;
    }

    public Task SaveHistory(Account account, AccountOperationType operationTypeType, long balanceDiff)
    {
        return Task.CompletedTask;
    }
}