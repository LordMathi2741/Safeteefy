namespace BasePlatform.API.Operation.Interfaces.Resources;

public record UpdateGuardianResource(string Username, string FirstName, string LastName, string Gender, string Address, int UrgencyId);