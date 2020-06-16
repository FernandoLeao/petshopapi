using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByName
{
    public class GetCustomerByNameQueryHandler : IRequestHandler<GetCustomerByName, CustomerListVm>
    {
        private readonly IPetScheduleDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByNameQueryHandler(IPetScheduleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerListVm> Handle(GetCustomerByName request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                .Where(c => c.Name.Contains(request.Name))
                .ProjectTo<CustomerNameDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var vm = new CustomerListVm
            {
                Customers = customers
            };

            return vm;
        }
    }
}
