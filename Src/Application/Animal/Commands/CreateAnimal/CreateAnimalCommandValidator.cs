using FluentValidation;
using PestSchedule.Application.Common.Interfaces;

namespace PestSchedule.Application.Animal.Commands.CreateAnimal
{
    public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
    {
        private readonly IPetScheduleDbContext _dbcontext;
        public CreateAnimalCommandValidator(IPetScheduleDbContext dbcontext) 
        {
            _dbcontext = dbcontext;
            //poderia verificar se o id existe na base
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome do seu animal em branco");
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("Idade deve ser maior que zero");
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Cliente não identificado");
            RuleFor(x => x.AnimalTypeId).GreaterThan(0).WithMessage("Tipo Animal não identificado");

        }
    }  
}
