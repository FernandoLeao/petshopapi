using MediatR;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByName
{
    public class GetCustomerByName : IRequest<CustomerListVm>
    {
        public string Name { get; set; }
    }
 
}
