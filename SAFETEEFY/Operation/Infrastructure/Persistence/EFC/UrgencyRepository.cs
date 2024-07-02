using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Operation.Domain.Repositories;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasePlatform.API.Operation.Infrastructure.Persistence.EFC;

public class UrgencyRepository(AppDbContext context): BaseRepository<Urgency>(context), IUrgencyRepository
{
    public bool ExistsByTtleAndGeolocationAtTheSameTime(string title, double latitude, double longitude, DateTime reportedAt)
    {
        return context.Set<Urgency>().Any(u => u.Title == title && u.Latitude == latitude && u.Longitude == longitude && u.ReportedAt.Date.Year == reportedAt.Date.Year);
    }

    public async Task<IEnumerable<Urgency>> FindUrgenciesByGuardianId(int guardianId)
    {
        return await context.Set<Urgency>().Where(u => u.GuardianId == guardianId).ToListAsync();
    }
}