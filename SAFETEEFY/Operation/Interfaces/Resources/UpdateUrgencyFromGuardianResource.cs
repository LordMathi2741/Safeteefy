namespace BasePlatform.API.Operation.Interfaces.Resources;

public record UpdateUrgencyFromGuardianResource(string Title, string Summary, double Latitude, double Longitude, int GuardianId);