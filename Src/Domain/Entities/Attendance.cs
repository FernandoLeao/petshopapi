using PestSchedule.Domain.Common;
using System;

namespace PestSchedule.Domain.Entities
{
    public class Attendance : Entity
    {
        public string Diagnostic { get; set; }
        public DateTime AttendanceDate { get; set; }

        public int VeterinaryId { get; set; }
        public Veterinary Veterinary { get; set; }

        public int AnimalId { get; set; }
        public Animal Aninmal { get; set; }
    }
}
