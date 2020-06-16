using MediatR;
using PestSchedule.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommand : IRequest
    {
        public int VeterinaryId { get; set; }
        public int AnimalId { get; set; }
        public DateTime ScheduleDate { get; set; }


        public class Handler : IRequestHandler<CreateScheduleCommand>
        {
            private readonly IPetScheduleDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IPetScheduleDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.Schedule
                {
                    VeterinaryId = request.VeterinaryId,
                    AnimalId = request.AnimalId,
                    ScheduleDate = request.ScheduleDate                  
                };

                _context.Schedules.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

