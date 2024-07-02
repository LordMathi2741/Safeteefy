

using BasePlatform.API.Operation.Domain.Model.Aggregates;
using BasePlatform.API.Operation.Domain.Model.Commands;
using BasePlatform.API.Operation.Domain.Model.Entities;

namespace BasePlatform.API.Operation.Domain.Services;

public interface IGuardianCommandService
{
    Task<Guardian?> Handle(CreateGuardianCommand command);
    Task<Urgency?> Handle(AddUrgencyToGuardianCommand command);
    Task<Guardian?> Handle(UpdateGuardianCommand command);
    Task<Guardian?> Handle(DeleteGuardianCommand command);
    Task<Urgency?> Handle(DeleteUrgencyFromGuardianCommand command);

    Task<Urgency?> Handle(UpdateUrgencyFromGuardianCommand command);
}