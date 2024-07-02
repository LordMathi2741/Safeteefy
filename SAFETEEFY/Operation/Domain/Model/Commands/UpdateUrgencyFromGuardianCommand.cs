namespace BasePlatform.API.Operation.Domain.Model.Commands;

public record UpdateUrgencyFromGuardianCommand(int Id,string Title, string Summary, double Latitude, double Longitude, int GuardianId);