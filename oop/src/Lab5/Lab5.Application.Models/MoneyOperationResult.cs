namespace Lab5.Models;

public abstract record MoneyOperationResult
{
    private MoneyOperationResult() { }

    public sealed record Success : MoneyOperationResult;

    public sealed record Fail : MoneyOperationResult;
}