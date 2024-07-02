using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class DeleteUrgencyFromGuardianCommandFromResourceAssembler
{
    public static DeleteUrgencyFromGuardianCommand ToCommandFromResource(DeleteUrgencyFromGuardianResource deleteUrgencyFromGuardianResource)
    {
        return new DeleteUrgencyFromGuardianCommand(deleteUrgencyFromGuardianResource.Id);
    }
}