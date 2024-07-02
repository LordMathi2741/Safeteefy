using BasePlatform.API.Operation.Domain.Model.Entities;

namespace BasePlatform.API.Operation.Interfaces.Resources;

public record CreateGuardianResource(string Username, string FirstName, string LastName, string Gender, string Address, int UrgencyId);