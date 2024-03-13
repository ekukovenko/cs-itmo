using Application.Managers;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Admins;
using Lab5.Models;

namespace Application.Services;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IAdminRepository _adminRepository;
    private readonly IHistoryRepository _historyRepository;
    private readonly CurrentAccountManager? _currentAccountManager;

    public AdminService(IAccountRepository accountRepository, IAdminRepository adminRepository, IHistoryRepository historyRepository, CurrentAccountManager? currentAccountManager)
    {
        _accountRepository = accountRepository;
        _adminRepository = adminRepository;
        _historyRepository = historyRepository;
        _currentAccountManager = currentAccountManager;
    }

    public async Task<AdminOperationResult> SignUpAccount(string name, int pin)
    {
        Account? existingAccount = await _accountRepository.GetAccountByName(name).ConfigureAwait(false);

        if (existingAccount != null)
        {
            return new AdminOperationResult.Failed();
        }

        if (_currentAccountManager == null) return new AdminOperationResult.Success();
        _currentAccountManager.Account = await _adminRepository.CreateAccount(name, pin).ConfigureAwait(false);

        await _historyRepository.SaveHistory(_currentAccountManager.Account, AccountOperationType.DepositMoney, 0)
            .ConfigureAwait(false);

        return new AdminOperationResult.Success();
    }

    public async Task<AdminOperationResult> ChangePassword(long id, long newPassword)
    {
        Account? existingAccount = await _accountRepository.GetAccountById(id).ConfigureAwait(false);
        if (existingAccount is null)
        {
            return new AdminOperationResult.Failed();
        }

        await _adminRepository.ChangePassword(existingAccount.Id, newPassword).ConfigureAwait(false);
        return new AdminOperationResult.Success();
    }
}