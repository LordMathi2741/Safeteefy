using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class UrgencyResourceFromEntityAssembler
{
    public static UrgencyResource ToResourceFromEntity(Urgency urgency)
    {
        return new UrgencyResource(urgency.Id, urgency.Title,
            urgency.Summary, urgency.Latitude, urgency.Longitude, urgency.GuardianId);
    }
}