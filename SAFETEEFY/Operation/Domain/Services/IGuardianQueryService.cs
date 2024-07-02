using BasePlatform.API.Operation.Domain.Model.Aggregates;
using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Operation.Domain.Model.Queries;

namespace BasePlatform.API.Operation.Domain.Services;

public interface IGuardianQueryService
{
     Task<Guardian?> Handle(GetGuardianByIdQuery query);
     Task<IEnumerable<Guardian>> Handle(GetAllGuardiansQuery query);
     
     Task<IEnumerable<Urgency?>> Handle(GetAllUrgenciesByGuardianIdQuery query);
     Task<IEnumerable<Urgency>> Handle(GetAllUrgenciesQuery query);
}