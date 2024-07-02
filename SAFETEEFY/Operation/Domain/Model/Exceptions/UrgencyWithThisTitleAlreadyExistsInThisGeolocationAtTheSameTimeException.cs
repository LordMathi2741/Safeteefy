namespace BasePlatform.API.Operation.Domain.Model.Exceptions;

public class UrgencyWithThisTitleAlreadyExistsInThisGeolocationAtTheSameTimeException : Exception
{
    public UrgencyWithThisTitleAlreadyExistsInThisGeolocationAtTheSameTimeException() : base("Urgency with this title already exists in this geolocation at the same time")
    {
    }
}