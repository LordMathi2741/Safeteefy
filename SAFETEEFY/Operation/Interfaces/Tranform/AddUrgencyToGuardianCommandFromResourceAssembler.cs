using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class AddUrgencyToGuardianCommandFromResourceAssembler
{
    public static AddUrgencyToGuardianCommand ToCommandFromResource(int guardianId,AddUrgencyToGuardianResource resource)
    {
        return new AddUrgencyToGuardianCommand(resource.Title, resource.Summary,
            resource.Latitude, resource.Longitude, guardianId);
    }
}