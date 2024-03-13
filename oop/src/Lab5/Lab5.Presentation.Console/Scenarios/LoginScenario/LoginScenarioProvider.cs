using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console;

namespace Presentation.Console.Scenarios.Accounts.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly ICurrentAccountService _currentAccountService;

    public LoginScenarioProvider(
        IAccountService accountService,
        ICurrentAccountService currentAccountService)
    {
        _accountService = accountService;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.Account is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginScenario(_accountService);
        return true;
    }
}