using MallMedia.Infrastructure.Persistence;
using MallMedia.Infrastructure.Seeders.Data;

namespace MallMedia.Infrastructure.Seeders;

internal class DeviceTypeSeeder(ApplicationDbContext dbContext)
{
    public async Task Seed()
    {
        if (!dbContext.DeviceTypes.Any())
        {
            dbContext.DeviceTypes.AddRange(DeviceTypeData.deviceTypes);
            dbContext.SaveChanges();
        }
    }
}
