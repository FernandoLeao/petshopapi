using FluentValidation;
using PestSchedule.Application.Common.Interfaces;

namespace PestSchedule.Application.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommandValidator :  AbstractValidator<CreateScheduleCommand>
    {
        private readonly IPetScheduleDbContext _dbcontext;
        public CreateScheduleCommandValidator(IPetScheduleDbContext dbcontext)
        {
            _dbcontext = dbcontext;

            RuleFor(x => x.AnimalId).GreaterThan(0).WithMessage("Escolha um Animal");
            RuleFor(x => x.VeterinaryId).GreaterThan(0).WithMessage("Escolha um Veterinário");
            RuleFor(x => x.ScheduleDate).NotNull().WithMessage("Escolha uma data para o agendamento");

        }
    }
}
