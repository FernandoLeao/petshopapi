using AutoMapper;
using PestSchedule.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Application.Customer.Queries.GetGustomerByName
{
    public class CustomerNameDto : IMapFrom<Domain.Entities.Customer>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Customer, CustomerNameDto>();
        }
    }
}
