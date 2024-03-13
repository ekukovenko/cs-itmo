namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract record ValidationResults(string Comment)
{
    public string Comment { get; } = Comment;

    public record SuccessValidation(string Comment = "Success.") : ValidationResults(Comment);
    public record SuccessWithWarranty(string Comment = "") : ValidationResults(Comment);
    public record ValidationError(string Comment = "") : ValidationResults(Comment);
}