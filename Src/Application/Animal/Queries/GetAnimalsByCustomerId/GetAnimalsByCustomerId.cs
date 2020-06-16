using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Animal.Queries.GetAnimalsByCustomerId
{
    public class GetAnimalsByCustomerId : IRequest<AnimalListVm>
    {
        public int CustomerId { get; set; }


        public class GetAnimalsByCustomerIdQueryHandler : IRequestHandler<GetAnimalsByCustomerId, AnimalListVm>
        {
            private readonly IPetScheduleDbContext _context;
            private readonly IMapper _mapper;

            public GetAnimalsByCustomerIdQueryHandler(IPetScheduleDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AnimalListVm> Handle(GetAnimalsByCustomerId request, CancellationToken cancellationToken)
            {
                var animals = await _context.Animals
                    .Where(a => a.CustomerId == request.CustomerId)
                    .ProjectTo<AnimalDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                var vm = new AnimalListVm
                {
                    Animals = animals
                };

                return vm;
            }
        }
    }


    
}
