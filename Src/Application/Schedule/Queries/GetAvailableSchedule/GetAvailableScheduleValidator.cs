using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Application.Schedule.Queries.GetAvailableSchedule
{
    public class GetAvailableScheduleValidator : AbstractValidator<GetAvailableScheduleQuery>
    {
        public GetAvailableScheduleValidator()
        {
            RuleFor(v => v.SchudeleDate).NotNull().WithMessage("Data do agendamento vazia")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Data do agendamento está no passado");
        }
    }
}
