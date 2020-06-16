using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Veterinary.Queries.GetAllVeterinary
{
    public class GetAllVeterinaryQuery : IRequest<VeterinaryListVm>
    {

        public class GetAllVeterinaryQueryHandler : IRequestHandler<GetAllVeterinaryQuery, VeterinaryListVm>
        {
            private readonly IPetScheduleDbContext _dbcontext;
            private readonly IMapper _mapper;

            public GetAllVeterinaryQueryHandler(IPetScheduleDbContext context, IMapper mapper)
            {
                _dbcontext = context;
                _mapper = mapper;
            }

            public async Task<VeterinaryListVm> Handle(GetAllVeterinaryQuery request, CancellationToken cancellationToken)
            {
                var employees = await _dbcontext.Veterinaries
                    .ProjectTo<VeterinaryDto>(_mapper.ConfigurationProvider)
                    .OrderBy(e => e.Name)
                    .ToListAsync(cancellationToken);

                var vm = new VeterinaryListVm
                {
                    Veterinaries = employees
                };

                return vm;
            }
        }
    }
}

