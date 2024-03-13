using Lab5.Models;

namespace Lab5.Application.Contracts.Accounts;

public interface ICurrentAccountService
{
    Account? Account { get; }
}