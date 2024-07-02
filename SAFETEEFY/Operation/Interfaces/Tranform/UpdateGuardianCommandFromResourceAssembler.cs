using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class UpdateGuardianCommandFromResourceAssembler
{
    public static UpdateGuardianCommand ToCommandFromResource(int id,UpdateGuardianResource resource)
    {
        return new UpdateGuardianCommand(id, resource.Username, resource.FirstName, 
            resource.LastName, resource.Gender, resource.Address, resource.UrgencyId);
    }
}