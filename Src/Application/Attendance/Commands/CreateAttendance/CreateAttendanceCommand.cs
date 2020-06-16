using MediatR;
using PestSchedule.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Attendance.Commands.CreateAttendance
{
    public class CreateAttendanceCommand : IRequest
    {
        public int AnimalId { get; set; }
        public int VeterinaryId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Diagnostic { get; set; }

        public class Handler : IRequestHandler<CreateAttendanceCommand>
        {
            private readonly IPetScheduleDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IPetScheduleDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.Attendance
                {
                    AnimalId = request.AnimalId,
                    VeterinaryId = request.VeterinaryId,
                    AttendanceDate = request.AttendanceDate,
                    Diagnostic = request.Diagnostic
                };

                _context.Attendances.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

