using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.History;

namespace Lab5.Presentation.Console.Scenarios.CheckScenarios;

public class CheckHistoryScenarioProvider : IScenarioProvider
{
    private readonly IHistoryService _service;
    private readonly ICurrentAccountService _currentAccount;

    public CheckHistoryScenarioProvider(IHistoryService service, ICurrentAccountService currentAccount)
    {
        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Account is null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckHistoryScenario(_service);
        return true;
    }
}