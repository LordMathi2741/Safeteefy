namespace BasePlatform.API.Operation.Domain.Model.Commands;

public record AddUrgencyToGuardianCommand(string Title, string Summary, double Latitude, double Longitude, int GuardianId);