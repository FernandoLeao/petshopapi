using PestSchedule.Application.Common.Interfaces;
using PestSchedule.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.System.Commands.SeedInitialData
{
    public class SampleDataSeeder
    {
        private readonly IPetScheduleDbContext _context;
        public SampleDataSeeder(IPetScheduleDbContext context)
        {
            _context = context;
        }


        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (_context.AnimalTypes.Any())
            {
                return;
            }

            await SeedAnimalType(cancellationToken);
            await SeedVeterinary(cancellationToken);
        }


        private async Task SeedAnimalType(CancellationToken cancellationToken)
        {
            var animalsType = new[]
            {
                new AnimalType { Name = "Cachorro", AgeConsideredOld = 7},
                new AnimalType { Name = "Gato", AgeConsideredOld = 7},
                new AnimalType { Name = "Hamster", AgeConsideredOld = 2},
            };
            _context.AnimalTypes.AddRange(animalsType);
            await _context.SaveChangesAsync(cancellationToken);
        }


        private async Task SeedVeterinary(CancellationToken cancellationToken)
        {
            var veterinaries = new[]
            {
                new Domain.Entities.Veterinary { Name = "Feranndo", ContractDate = new DateTime(), IsGeriatric = false},
                new Domain.Entities.Veterinary { Name = "Geraldo", ContractDate = new DateTime(), IsGeriatric = true},
                new Domain.Entities.Veterinary { Name = "Vanessa", ContractDate = new DateTime(), IsGeriatric = false},
            };
            _context.Veterinaries.AddRange(veterinaries);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
