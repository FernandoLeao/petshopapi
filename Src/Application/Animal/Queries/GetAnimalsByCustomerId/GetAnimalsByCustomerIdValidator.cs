using FluentValidation;

namespace PestSchedule.Application.Animal.Queries.GetAnimalsByCustomerId
{
    class GetAnimalsByCustomerIdValidator : AbstractValidator<GetAnimalsByCustomerId>
    {
        public GetAnimalsByCustomerIdValidator()
        {
            RuleFor(v => v.CustomerId).NotEmpty().WithMessage("Id do Cliente não pode ser vazio");
        }
    }    
}
