namespace BasePlatform.API.Operation.Interfaces.Resources;

public record UrgencyResource(int Id,string Title, string Summary, double Latitude, double Longitude, int GuardianId);