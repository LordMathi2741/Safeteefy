using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Shared.Domain.Repositories;

namespace BasePlatform.API.Operation.Domain.Repositories;

public interface IUrgencyRepository : IBaseRepository<Urgency>
{
    bool ExistsByTtleAndGeolocationAtTheSameTime(string title, double latitude, double longitude, DateTime reportedAt);
    Task<IEnumerable<Urgency>> FindUrgenciesByGuardianId(int guardianId);
    
}