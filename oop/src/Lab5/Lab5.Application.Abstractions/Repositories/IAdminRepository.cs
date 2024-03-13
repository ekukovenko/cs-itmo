using Lab5.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Account> CreateAccount(string name, int pin);
    Task ChangePassword(long id, long password);
}