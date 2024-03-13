using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CheckScenarios;

public class CheckBalanceScenario : IScenario
{
    private readonly IAccountService _accountService;

    public CheckBalanceScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Check account balance";

    public void Run()
    {
        string name = AnsiConsole.Ask<string>("Enter your name");
        int pin = AnsiConsole.Ask<int>("Enter PIN");

        long? balanceValue = _accountService.CheckBalance(name, pin).ConfigureAwait(false).GetAwaiter().GetResult();

        AnsiConsole.WriteLine("Balance:" + $" {balanceValue}");
        AnsiConsole.Ask<string>("Ok");
    }
}