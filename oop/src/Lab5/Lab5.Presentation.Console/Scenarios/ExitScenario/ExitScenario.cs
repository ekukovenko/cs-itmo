using Application.Managers;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.ExitScenario;

public class ExitScenario : IScenario
{
    private readonly CurrentAccountManager _accountManager;

    public ExitScenario(CurrentAccountManager accountManager)
    {
        _accountManager = accountManager;
    }

    public string Name => "Exit";

    public void Run()
    {
        if (_accountManager.Account is null)
        {
            Environment.Exit(0);
        }

        _accountManager.Account = null;
        AnsiConsole.Ask<string>("Ok");
    }
}