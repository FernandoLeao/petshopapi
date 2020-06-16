using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Application.Animal.Queries.GetAnimalsByCustomerId
{
    public class AnimalListVm
    {
        public IList<AnimalDto> Animals { get; set; }
    }
}
