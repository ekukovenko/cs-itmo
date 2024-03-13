using Lab5.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    void UpdateBalance(Account account, long money);

    Task<Account?> GetAccountByName(string name);
    Task<Account?> GetAccountById(long id);
}