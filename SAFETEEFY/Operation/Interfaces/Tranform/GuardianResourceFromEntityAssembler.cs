using BasePlatform.API.Operation.Domain.Model.Aggregates;
using BasePlatform.API.Operation.Interfaces.Resources;

namespace BasePlatform.API.Operation.Interfaces.Tranform;

public class GuardianResourceFromEntityAssembler
{
    public static GuardianResource ToResourceFromEntity(Guardian guardian)
    {
        return new GuardianResource(guardian.Username, guardian.FirstName, guardian.LastName, guardian.Gender,
            guardian.Address);
    }
}