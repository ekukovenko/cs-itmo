using Lab5.Application.Abstractions.Repositories;
using Lab5.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class AccountRepositoryMock : IAccountRepository
{
    private IList<Account> _accounts;

    public AccountRepositoryMock(IList<Account> accounts)
    {
        _accounts = accounts;
    }

    public Task<Account?> GetAccountByName(string name) =>
        Task.FromResult(_accounts.ToList().Find(ac => ac.Name == name));

    public Task<Account?> GetAccountById(long id)
    {
        throw new NotImplementedException();
    }

    public void UpdateBalance(Account account, long money)
    {
        _ = new Account(account.Id, account.Name, account.Pin, new Balance(money));
    }
}