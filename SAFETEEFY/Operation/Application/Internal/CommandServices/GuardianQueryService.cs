using BasePlatform.API.Operation.Domain.Model.Aggregates;
using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Operation.Domain.Model.Queries;
using BasePlatform.API.Operation.Domain.Repositories;
using BasePlatform.API.Operation.Domain.Services;

namespace BasePlatform.API.Operation.Application.Internal.CommandServices;

public class GuardianQueryService(IGuardianRepository guardianRepository, IUrgencyRepository urgencyRepository) : IGuardianQueryService
{
    public async Task<Guardian?> Handle(GetGuardianByIdQuery query)
    {
        return await guardianRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Guardian>> Handle(GetAllGuardiansQuery query)
    {
        return await guardianRepository.ListAsync();
    }

    public async Task<IEnumerable<Urgency?>> Handle(GetAllUrgenciesByGuardianIdQuery query)
    {
        return await urgencyRepository.FindUrgenciesByGuardianId(query.GuardianId);
    }

    public async Task<IEnumerable<Urgency>> Handle(GetAllUrgenciesQuery query)
    {
        return await urgencyRepository.ListAsync();
    }
}