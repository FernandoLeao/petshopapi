using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Schedule.Queries.GetAvailableSchedule
{
    public class GetAvailableScheduleQuery: IRequest<ScheduleListVm>
    {
        public int VeterinaryId { get; set; }
        public DateTime SchudeleDate { get; set; }
        public class GetAvailableScheduleQueryHandler : IRequestHandler<GetAvailableScheduleQuery, ScheduleListVm>
        {
            private readonly IPetScheduleDbContext _dbcontext;
            private readonly IMapper _mapper;

            public GetAvailableScheduleQueryHandler(IPetScheduleDbContext context, IMapper mapper)
            {
                _dbcontext = context;
                _mapper = mapper;
            }

            public async Task<ScheduleListVm> Handle(GetAvailableScheduleQuery request, CancellationToken cancellationToken)
            {
                var veterinaries = await _dbcontext.Veterinaries
                                    .Where(x => x.Id == request.VeterinaryId
                                           || request.VeterinaryId == 0).ToListAsync();

                var schedules = await _dbcontext.Schedules
                            .Where(x => x.ScheduleDate.Date == request.SchudeleDate.Date).ToListAsync();


                var start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,8,0,0);
                var clockQuery = from offset in Enumerable.Range(0, 18)
                                 select start.AddMinutes(30 * offset);

                var scheduleRoot = new ScheduleDto();

                foreach (var vet in veterinaries)
                {
                    var veterinaryDto = new ScheduleVeterinaryDto();
                    veterinaryDto.Id = vet.Id;
                    veterinaryDto.Name = vet.Name;
                    veterinaryDto.Agenda = new List<ScheduleAgendaDto>();

                    foreach (var time in clockQuery)
                    {
                        var dateHour = new DateTime(request.SchudeleDate.Year,
                                     request.SchudeleDate.Month,
                                     request.SchudeleDate.Day,
                                     time.Hour,
                                     time.Minute,
                                     time.Minute, 0);

                        var hourAvailable = !schedules.Any(x => x.VeterinaryId == vet.Id &&
                                                        x.ScheduleDate.Equals(dateHour));
                        if (hourAvailable)
                        {
                            veterinaryDto.Agenda.Add(new ScheduleAgendaDto()
                            {
                                Date = dateHour,
                                Available = hourAvailable,
                                Hour = (time.Hour.ToString()).PadLeft(2, '0') + ":" + (time.Minute.ToString()).PadLeft(2, '0')
                            });
                        }

                       
                    }

                    scheduleRoot.Veterinaries.Add(veterinaryDto);
                }

                var vm = new ScheduleListVm
                {
                    Schedule = scheduleRoot
                };

                return vm;
            }
        }
    }
}

