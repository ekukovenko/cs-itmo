using System.Collections.Generic;
using Application.Managers;
using Application.Services;
using Infrastructure.DataAccess.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Lab5.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ServiceTests
{
    [Fact]
    public void AddMoneyAccountExistsSuccess()
    {
        var account = new Account(1, "test", 111, new Balance(0));
        var manager = new CurrentAccountManager();
        manager.Account = account;

        var accounts = new List<Account>()
        {
            account,
        };

        var service = new AccountService(
            new AccountRepositoryMock(accounts),
            manager,
            new HistoryRepositoryMock());

        AddMoneyResult actual = service.AddMoney(100);

        Assert.IsType<AddMoneyResult.Success>(actual);
    }

    [Fact]
    public void WithdrawMoneyEnoughMoneySuccess()
    {
        var account = new Account(2, "test", 111, new Balance(110));
        var manager = new CurrentAccountManager();
        manager.Account = account;

        var accounts = new List<Account>()
        {
            account,
        };

        var service = new AccountService(
            new AccountRepositoryMock(accounts),
            manager,
            new HistoryRepositoryMock());

        WithdrawMoneyResult actual = service.WithdrawMoney(100);

        Assert.IsType<WithdrawMoneyResult.Success>(actual);
    }

    [Fact]
    public void WithdrawMoneyNotEnoughMoneyFail()
    {
        var account = new Account(3, "test", 111, new Balance(110));
        var manager = new CurrentAccountManager();
        manager.Account = account;

        var accounts = new List<Account>()
        {
            account,
        };

        var service = new AccountService(
            new AccountRepositoryMock(accounts),
            manager,
            new HistoryRepositoryMock());

        WithdrawMoneyResult actual = service.WithdrawMoney(150);

        Assert.IsType<WithdrawMoneyResult.NotEnoughMoney>(actual);
    }
}