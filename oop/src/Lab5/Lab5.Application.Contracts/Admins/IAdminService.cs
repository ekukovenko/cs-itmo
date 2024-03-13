using Lab5.Models;

namespace Lab5.Application.Contracts.Admins;

public interface IAdminService
{
    Task<AdminOperationResult> SignUpAccount(string name, int pin);
}