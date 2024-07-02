namespace BasePlatform.API.Operation.Domain.Model.Exceptions;

public class FirstNameAndLastNameMustBeRequiredException : Exception
{
    public FirstNameAndLastNameMustBeRequiredException() : base("First name and last name must be required")
    {
    }
}