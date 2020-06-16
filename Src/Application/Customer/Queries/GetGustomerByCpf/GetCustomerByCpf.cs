using MediatR;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByCpf
{
    public class GetCustomerByCpf : IRequest<CustomerDetailCpfVm>
    {
        public string Cpf { get; set; }
    }
 
}
