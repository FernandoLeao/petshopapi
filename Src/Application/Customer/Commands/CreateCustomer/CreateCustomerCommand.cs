using MediatR;
using PestSchedule.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string Cpf { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<CreateCustomerCommand>
        {
            private readonly IPetScheduleDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IPetScheduleDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.Customer
                {
                    Cpf = request.Cpf,
                    Name = request.Name
                };

                _context.Customers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);              

                return Unit.Value;
            }
        }
    }
}
