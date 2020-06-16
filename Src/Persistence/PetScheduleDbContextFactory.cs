using Microsoft.EntityFrameworkCore;
using System;

namespace PetSchedule.Persistence
{

    public class PetScheduleDbContextFactory : DesignTimeDbContextFactoryBase<PetScheduleDbContext>
    {
        protected override PetScheduleDbContext CreateNewInstance(DbContextOptions<PetScheduleDbContext> options)
        {
            return new PetScheduleDbContext(options);
        }
    }
}
