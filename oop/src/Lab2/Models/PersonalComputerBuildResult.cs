namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public abstract record PersonalComputerBuildResult(string Comment)
{
    public string Comment { get; } = Comment;

    public record Success(PersonalComputer Computer, string Comment = "") : PersonalComputerBuildResult(Comment);
    public record NoRequiredComponents(string Comment = "") : PersonalComputerBuildResult(Comment);
    public record СomponentsDontFitEachOther(PersonalComputer Computer, string Comment = "") : PersonalComputerBuildResult(Comment);
    public record SuccessWithWarrantyDisclaimer(PersonalComputer Computer, string Comment) : PersonalComputerBuildResult(Comment);
}