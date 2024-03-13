using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Admins;

namespace Lab5.Presentation.Console.Scenarios.CreateScenario;

public class CreateAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAccountService _currentAccount;

    public CreateAccountScenarioProvider(IAdminService service, ICurrentAccountService currentAccount)
    {
        _service = service;
        _currentAccount = currentAccount;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccount.Account is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateAccountScenario(_service);
        return true;
    }
}