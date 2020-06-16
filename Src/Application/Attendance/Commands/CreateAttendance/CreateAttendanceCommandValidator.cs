using FluentValidation;
using PestSchedule.Application.Common.Interfaces;
using System;

namespace PestSchedule.Application.Attendance.Commands.CreateAttendance
{
    public class CreateAttendanceCommandValidator : AbstractValidator<CreateAttendanceCommand>
    {
        private readonly IPetScheduleDbContext _dbcontext;

        public CreateAttendanceCommandValidator(IPetScheduleDbContext dbcontext)
        {
            _dbcontext = dbcontext;

            //poderia validar os ids

            RuleFor(x => x.AnimalId).GreaterThan(0).WithMessage("Escolha um animal");
            RuleFor(x=> x.VeterinaryId).GreaterThan(0).WithMessage("Escolha um veterinário");
            RuleFor(x => x.Diagnostic).NotEmpty().WithMessage("Digite um diagnostico para o animal escolhido");
            RuleFor(x => x.AttendanceDate).NotNull().WithMessage("Digite uma data para o atendimento")
                    .LessThanOrEqualTo( DateTime.Today).WithMessage("Data do atendimento está no futuro");
        }
    }
}
