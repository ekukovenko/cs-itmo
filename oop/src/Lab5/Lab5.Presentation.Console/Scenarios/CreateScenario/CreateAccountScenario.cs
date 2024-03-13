using Lab5.Application.Contracts.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.CreateScenario;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create an account";

    public void Run()
    {
        string name = AnsiConsole.Ask<string>("Enter name");
        int pin = AnsiConsole.Ask<int>("Enter PIN");

        _adminService.SignUpAccount(name, pin);

        string message = $"New account registered - Name: {name}, Password: {pin}";

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}