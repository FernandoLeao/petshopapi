using FluentValidation;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByCpf
{
    public class GetCustomerByCpfValidator : AbstractValidator<GetCustomerByCpf>
    {
        public GetCustomerByCpfValidator()
        {
            RuleFor(v => v.Cpf).NotEmpty();
        }
    }    
}
