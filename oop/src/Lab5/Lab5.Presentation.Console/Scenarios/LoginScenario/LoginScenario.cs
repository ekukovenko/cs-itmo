using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console;
using Spectre.Console;

namespace Presentation.Console.Scenarios.Accounts.Login;

public class LoginScenario : IScenario
{
    private readonly IAccountService _accountService;

    public LoginScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Login account";

    public async void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter username");
        int pin = AnsiConsole.Ask<int>("Enter password");

        LoginResult result = await _accountService.Login(username, pin).ConfigureAwait(false);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "Account not found",
            LoginResult.IncorrectPassword => "Incorrect password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}