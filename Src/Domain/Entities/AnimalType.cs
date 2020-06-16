using PestSchedule.Domain.Common;
using System.Collections.Generic;

namespace PestSchedule.Domain.Entities
{
    public class AnimalType : Entity
    {
        public AnimalType() {
            Animals = new HashSet<Animal>();
        }
        public string Name { get; set; }
        public int AgeConsideredOld {get;set;}
        public ICollection<Animal> Animals { get; private set; }
    }
}
