namespace Lab5.Application.Contracts.Accounts;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;
    public sealed record IncorrectPassword : LoginResult;
}