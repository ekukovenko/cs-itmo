using Lab5.Models;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    WithdrawMoneyResult WithdrawMoney(long money);

    AddMoneyResult AddMoney(long money);

    Task<long?> CheckBalance(string name, int pin);

    Task<LoginResult> Login(string username, int pin);
}