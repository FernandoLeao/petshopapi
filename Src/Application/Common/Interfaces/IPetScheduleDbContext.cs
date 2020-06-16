using Microsoft.EntityFrameworkCore;
using PestSchedule.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Common.Interfaces
{

    public interface IPetScheduleDbContext
    {
        DbSet<Domain.Entities.Customer> Customers { get; set; }

        DbSet<Domain.Entities.Animal> Animals { get; set; }

        DbSet<Domain.Entities.AnimalType> AnimalTypes { get; set; }

        DbSet<Domain.Entities.Veterinary> Veterinaries { get; set; }

        DbSet<Domain.Entities.Attendance> Attendances { get; set; }

        DbSet<Domain.Entities.Schedule> Schedules { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
