using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class UpdateUrgencyFromGuardianCommandFromResourceAssembler
{
    public static UpdateUrgencyFromGuardianCommand ToCommandFromResource(int id,UpdateUrgencyFromGuardianResource resource)
    {
        return new UpdateUrgencyFromGuardianCommand(id, resource.Title, resource.Summary,
            resource.Latitude, resource.Longitude, resource.GuardianId);
    }
}