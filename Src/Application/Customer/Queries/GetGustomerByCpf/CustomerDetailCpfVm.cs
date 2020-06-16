using AutoMapper;
using PestSchedule.Application.Common.Mappings;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByCpf
{
    public  class CustomerDetailCpfVm : IMapFrom<Domain.Entities.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Customer, CustomerDetailCpfVm>();               
        }
    }
}