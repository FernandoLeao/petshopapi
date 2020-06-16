using PestSchedule.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Domain.Entities
{
    public class Veterinary : Entity
    {
        public Veterinary()
        {
            Attendances = new HashSet<Attendance>();
            Schedules = new HashSet<Schedule>();
        }
        public string Name { get; set; }
        public bool IsGeriatric { get; set; }
        public DateTime ContractDate { get; set; }

        public HashSet<Attendance> Attendances { get; private set; }
        public HashSet<Schedule> Schedules { get; private set; }
    }
}
