namespace Lab5.Models;

public abstract record AddMoneyResult
{
    private AddMoneyResult() { }

    public sealed record Success() : AddMoneyResult;

    public sealed record NotAuthorized : AddMoneyResult;

    public sealed record InvalidAmount : AddMoneyResult;
}