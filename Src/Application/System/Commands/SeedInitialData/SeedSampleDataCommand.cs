using MediatR;
using PestSchedule.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.System.Commands.SeedInitialData
{
    public class SeedSampleDataCommand : IRequest
    {
    }
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IPetScheduleDbContext _context;

        public SeedSampleDataCommandHandler(IPetScheduleDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
