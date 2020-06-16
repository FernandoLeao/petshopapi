using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;
using PestSchedule.Domain.Common;
using PestSchedule.Domain.Entities;
using PetSchedule.Persistence.Extension;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetSchedule.Persistence
{
    public class PetScheduleDbContext : DbContext, IPetScheduleDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public PetScheduleDbContext(DbContextOptions<PetScheduleDbContext> options)
            : base(options)
        {
        }

        public PetScheduleDbContext(
            DbContextOptions<PetScheduleDbContext> options,
            ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Schedule> Schedules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
            //base.OnModelCreating(modelBuilder)
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
