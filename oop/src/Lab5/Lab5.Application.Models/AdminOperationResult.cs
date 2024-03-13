namespace Lab5.Models;

public record AdminOperationResult
{
    private AdminOperationResult() { }

    public sealed record Success : AdminOperationResult;

    public sealed record Failed : AdminOperationResult;
}