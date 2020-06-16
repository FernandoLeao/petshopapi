using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Attendance.Queries.GetAttendanceByCustomerId
{
    public class GetAttendanceByCustomerIdQuery : IRequest<AttendanceListVm>
    {
        public int CustomerId { get; set; }

        public class GetAttendanceByCustomerIdHandler : IRequestHandler<GetAttendanceByCustomerIdQuery, AttendanceListVm>
        {
            private readonly IPetScheduleDbContext _context;
            private readonly IMapper _mapper;

            public GetAttendanceByCustomerIdHandler(IPetScheduleDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AttendanceListVm> Handle(GetAttendanceByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var attendances = await _context.Attendances
                    .OrderByDescending(e => e.Id)
                    .Where( x=> x.Aninmal.CustomerId == request.CustomerId)
                    .ProjectTo<AttendanceDto>(_mapper.ConfigurationProvider)                    
                    .ToListAsync(cancellationToken);

                var vm = new AttendanceListVm
                {
                    Attendances = attendances
                };

                return vm;
            }
        }
    }
}

