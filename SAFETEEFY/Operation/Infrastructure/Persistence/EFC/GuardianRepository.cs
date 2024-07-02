using BasePlatform.API.Operation.Domain.Model.Aggregates;
using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Operation.Domain.Repositories;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace BasePlatform.API.Operation.Infrastructure.Persistence.EFC;

public class GuardianRepository(AppDbContext context) : BaseRepository<Guardian>(context), IGuardianRepository
{
 
}