using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Exceptions;
using PestSchedule.Application.Common.Interfaces;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByCpf
{
    public class GetCustomerByNameQueryHandler : IRequestHandler<GetCustomerByCpf, CustomerDetailCpfVm>
    {
        private readonly IPetScheduleDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByNameQueryHandler(IPetScheduleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDetailCpfVm> Handle(GetCustomerByCpf request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Cpf.Equals(request.Cpf));

            if (entity == null)
            {
                throw new NotFoundException("Cliente não encontrado com cpf fornecido");
            }

            return _mapper.Map<CustomerDetailCpfVm>(entity);
        }
    }
}
