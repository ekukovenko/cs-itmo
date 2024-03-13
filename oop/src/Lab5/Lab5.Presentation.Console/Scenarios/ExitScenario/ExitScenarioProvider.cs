using System.Diagnostics.CodeAnalysis;
using Application.Managers;

namespace Lab5.Presentation.Console.Scenarios.ExitScenario;

public class ExitScenarioProvider : IScenarioProvider
{
    private readonly CurrentAccountManager _accountManager;

    public ExitScenarioProvider(CurrentAccountManager accountManager)
    {
        _accountManager = accountManager;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        scenario = new ExitScenario(_accountManager);
        return true;
    }
}