namespace Lab5.Models;

public abstract record WithdrawMoneyResult
{
    public sealed record Success() : WithdrawMoneyResult;

    public sealed record NotAuthorized : WithdrawMoneyResult;

    public sealed record NotEnoughMoney : WithdrawMoneyResult;

    public sealed record InvalidAmount : WithdrawMoneyResult;
}