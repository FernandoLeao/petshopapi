using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PestSchedule.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace PestSchedule.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IPetScheduleDbContext _dbcontext;
        public CreateCustomerCommandValidator(IPetScheduleDbContext dbcontext)
        {
            _dbcontext = dbcontext;

            RuleFor(x => x.Cpf).NotEmpty().WithMessage("Cpf em branco")
                               .MaximumLength(11).WithMessage("Tamanho maior que 12 caracteres")
                               .Must(cpf=> ValidCpf(cpf)).WithMessage("Cpf inválido")
                               .MustAsync( (cpf, cancellationToken ) => CustomerFoundWithThisCpf(cpf)).WithMessage("Cpf já cadastrado");
        }

        private async Task<bool> CustomerFoundWithThisCpf(string cpf)
        {
            var customer = await _dbcontext.Customers.FirstOrDefaultAsync(x => x.Cpf.Equals(cpf));
            return !(customer != null);
        }

        private bool ValidCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            if ((cpf == "00000000000") || (cpf == "11111111111") || (cpf == "22222222222") || (cpf == "33333333333") || (cpf == "44444444444") || (cpf == "55555555555") || (cpf == "66666666666") || (cpf == "77777777777") || (cpf == "88888888888") || (cpf == "99999999999"))
            {
                return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
