using Lab5.Application.Contracts.Accounts;
using Lab5.Models;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.MoneyOperationsScenarios;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawMoneyScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw money";

    public void Run()
    {
        long moneyAmount = AnsiConsole.Ask<long>("Enter money amount");

        WithdrawMoneyResult result = _accountService.WithdrawMoney(moneyAmount);

        string message = result switch
        {
            WithdrawMoneyResult.Success => "Successful withdraw",
            WithdrawMoneyResult.NotEnoughMoney => "Not enough money on balance",
            WithdrawMoneyResult.InvalidAmount => "Invalid amount of money",
            WithdrawMoneyResult.NotAuthorized => "You are not authorized",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}