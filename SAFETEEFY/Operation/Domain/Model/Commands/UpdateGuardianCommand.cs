namespace BasePlatform.API.Operation.Domain.Model.Commands;

public record UpdateGuardianCommand(int Id,string Username, string FirstName, string LastName, string Gender, string Address,int UrgencyId);