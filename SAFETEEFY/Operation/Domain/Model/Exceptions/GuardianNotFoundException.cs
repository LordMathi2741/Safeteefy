namespace BasePlatform.API.Operation.Domain.Model.Exceptions;

public class GuardianNotFoundException : Exception
{
    public GuardianNotFoundException() : base("Guardian not found")
    {
        
    }
}