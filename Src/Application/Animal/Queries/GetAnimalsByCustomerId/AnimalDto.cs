using AutoMapper;
using PestSchedule.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Application.Animal.Queries.GetAnimalsByCustomerId
{
    public class AnimalDto : IMapFrom<Domain.Entities.Animal>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int AnimalTypeId { get; set; }
        public int CustomerId { get; set; }

        public bool IsOldAnimal { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Animal, AnimalDto>();
        }
    }
}
