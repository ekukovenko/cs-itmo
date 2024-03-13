using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.History;
using Lab5.Models;

namespace Application.Services;

public class HistoryService : IHistoryService
{
    private readonly IHistoryRepository _historyRepository;

    public HistoryService(IHistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public IAsyncEnumerable<Operation>? CheckHistory(Account account)
    {
        return _historyRepository.CheckHistory(account);
    }
}