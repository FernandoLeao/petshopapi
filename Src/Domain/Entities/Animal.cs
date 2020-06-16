using PestSchedule.Domain.Common;
using System.Collections.Generic;

namespace PestSchedule.Domain.Entities
{
    public class Animal : Entity
    {
        public Animal()
        {
            Attendances = new HashSet<Attendance>();
            Schedules = new HashSet<Schedule>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; }
        public bool IsOldAnimal { get { return Age > AnimalType.AgeConsideredOld; } }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public HashSet<Attendance> Attendances { get; private set; }
        public HashSet<Schedule> Schedules { get; private set; }

    }
}
