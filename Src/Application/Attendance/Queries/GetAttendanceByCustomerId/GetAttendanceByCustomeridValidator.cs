using FluentValidation;

namespace PestSchedule.Application.Attendance.Queries.GetAttendanceByCustomerId
{
    public class GetAttendanceByCustomeridValidator : AbstractValidator<GetAttendanceByCustomerIdQuery>
    {
        public GetAttendanceByCustomeridValidator()
        {
            RuleFor(v => v.CustomerId).NotEmpty();
        }
    }
}
