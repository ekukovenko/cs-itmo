namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ValidationError
{
    public ValidationError(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; set; }
}