using MediatR;
using PestSchedule.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PestSchedule.Application.Animal.Commands.CreateAnimal
{
    public class CreateAnimalCommand : IRequest
    {
        public string Name { get; set; }
        public int AnimalTypeId { get; set; }

        public int CustomerId { get; set; }
        public int Age { get; set; }

        public class Handler : IRequestHandler<CreateAnimalCommand>
        {
            private readonly IPetScheduleDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IPetScheduleDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
            {
                var entity = new Domain.Entities.Animal
                {
                    Age = request.Age,
                    CustomerId = request.CustomerId,
                    AnimalTypeId = request.AnimalTypeId,
                    Name = request.Name
                };

                _context.Animals.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }           
        }
    }
}

