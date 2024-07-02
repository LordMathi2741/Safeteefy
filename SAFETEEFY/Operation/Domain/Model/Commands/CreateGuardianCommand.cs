using BasePlatform.API.Operation.Domain.Model.Entities;

namespace BasePlatform.API.Operation.Domain.Model.Commands;

public record CreateGuardianCommand(int UrgencyId,string Username, string FirstName, string LastName, string Gender, string Address );