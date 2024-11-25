using MallMedia.Infrastructure.Persistence;
using MallMedia.Infrastructure.Seeders.Data;

namespace MallMedia.Infrastructure.Seeders
{
    internal class LocationSeeder(ApplicationDbContext dbContext)
    {
        public async Task Seed()
        {
            if (!dbContext.Locations.Any())
            {
                dbContext.Locations.AddRange(LocationData.Locations);
                dbContext.SaveChanges();
            }
        }

    }

}
