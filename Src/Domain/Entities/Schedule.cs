using PestSchedule.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Domain.Entities
{
    public class Schedule : Entity
    {
        public DateTime ScheduleDate { get; set; }

        public int AnimalId { get; set; }
        public Animal Aninmal { get; set; }

        public int VeterinaryId { get; set; }
        public Veterinary Veterinary { get; set; }
    }
}
