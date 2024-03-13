using Application.Managers;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Models;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly CurrentAccountManager _currentAccountManager;
    private readonly IHistoryRepository _historyRepository;

    public AccountService(IAccountRepository repository, CurrentAccountManager currentAccountManager, IHistoryRepository historyRepository)
    {
        _accountRepository = repository;
        _currentAccountManager = currentAccountManager;
        _historyRepository = historyRepository;
    }

    public WithdrawMoneyResult WithdrawMoney(long money)
    {
        if (_currentAccountManager.Account is null)
        {
            return new WithdrawMoneyResult.NotAuthorized();
        }

        if (_currentAccountManager.Account.Balance.Value < money)
        {
            return new WithdrawMoneyResult.NotEnoughMoney();
        }

        _currentAccountManager.Account = _currentAccountManager.Account with { Balance = new Balance(_currentAccountManager.Account.Balance.Value - money) };

        _accountRepository.UpdateBalance(
            _currentAccountManager.Account, money);

        _historyRepository.SaveHistory(_currentAccountManager.Account, AccountOperationType.WithdrawMoney, -money);

        return new WithdrawMoneyResult.Success();
    }

    public AddMoneyResult AddMoney(long money)
    {
        if (_currentAccountManager.Account is null)
        {
            return new AddMoneyResult.NotAuthorized();
        }

        if (money <= 0)
        {
            return new AddMoneyResult.InvalidAmount();
        }

        _currentAccountManager.Account = _currentAccountManager.Account with { Balance = new Balance(_currentAccountManager.Account.Balance.Value + money) };

        _accountRepository.UpdateBalance(_currentAccountManager.Account, money);

        _historyRepository.SaveHistory(_currentAccountManager.Account, AccountOperationType.DepositMoney, money);

        return new AddMoneyResult.Success();
    }

    public async Task<long?> CheckBalance(string name, int pin)
    {
        Account? account = await _accountRepository.GetAccountByName(name).ConfigureAwait(false);

        if (account != null && account.Pin == pin)
        {
            return account.Balance.Value;
        }

        return null;
    }

    public async Task<LoginResult> Login(string username, int pin)
    {
        Task<Account?> accountTask = _accountRepository.GetAccountByName(username);
        Account? account = await accountTask.ConfigureAwait(false);

        if (account == null)
        {
            return new LoginResult.NotFound();
        }

        if (account.Pin != pin)
        {
            return new LoginResult.IncorrectPassword();
        }

        _currentAccountManager.Account = account;
        return new LoginResult.Success();
    }
}