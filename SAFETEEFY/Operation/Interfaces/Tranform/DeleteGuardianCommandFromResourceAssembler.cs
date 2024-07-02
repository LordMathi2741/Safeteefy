using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class DeleteGuardianCommandFromResourceAssembler
{
    public static DeleteGuardianCommand ToCommandFromResource(DeleteGuardianResource deleteGuardianResource)
    {
        return new DeleteGuardianCommand(deleteGuardianResource.Id);
    }
}