using Lab5.Application.Contracts.Accounts;
using Lab5.Models;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.MoneyOperationsScenarios;

public class AddMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public AddMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Add money";

    public void Run()
    {
        long moneyAmount = AnsiConsole.Ask<long>("Enter money amount");

        AddMoneyResult result = _accountService.AddMoney(moneyAmount);

        string message = result switch
        {
            AddMoneyResult.Success => "Successful adding money",
            AddMoneyResult.NotAuthorized => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}