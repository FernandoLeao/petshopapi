using AutoMapper;
using PestSchedule.Application.Common.Mappings;
using System;

namespace PestSchedule.Application.Veterinary.Queries.GetAllVeterinary
{
    public class VeterinaryDto : IMapFrom<Domain.Entities.Veterinary>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGeriatric { get; set; }
        public DateTime ContractDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Veterinary, VeterinaryDto>();               
        }
    }
}
