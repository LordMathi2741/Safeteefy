using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class CreateGuardianCommandFromResourceAssembler
{
    public static CreateGuardianCommand ToCommandFromResource(CreateGuardianResource resource)
    {
        return new CreateGuardianCommand(resource.UrgencyId, resource.Username, resource.FirstName, resource.LastName, resource.Gender,
            resource.Address);
    }
}