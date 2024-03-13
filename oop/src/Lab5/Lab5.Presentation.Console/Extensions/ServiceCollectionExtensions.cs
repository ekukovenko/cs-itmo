using Lab5.Presentation.Console.Scenarios.CheckScenarios;
using Lab5.Presentation.Console.Scenarios.CreateScenario;
using Lab5.Presentation.Console.Scenarios.ExitScenario;
using Lab5.Presentation.Console.Scenarios.Mo;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ExitScenarioProvider>();

        return collection;
    }
}