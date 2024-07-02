namespace BasePlatform.API.Operation.Domain.Model.Exceptions;

public class UrgencyNotFoundException : Exception
{
    public UrgencyNotFoundException() : base("Urgency not found.")
    {
        
    }
}