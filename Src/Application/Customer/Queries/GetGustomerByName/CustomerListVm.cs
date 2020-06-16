using AutoMapper;
using PestSchedule.Application.Common.Mappings;
using System.Collections.Generic;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByName
{
    public  class CustomerListVm : IMapFrom<Domain.Entities.Customer>
    {
        public IList<CustomerNameDto> Customers { get; set; }
    }
}