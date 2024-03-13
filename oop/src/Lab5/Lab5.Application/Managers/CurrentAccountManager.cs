using Lab5.Application.Contracts.Accounts;
using Lab5.Models;

namespace Application.Managers;

public class CurrentAccountManager : ICurrentAccountService
{
    public Account? Account { get; set; }
}