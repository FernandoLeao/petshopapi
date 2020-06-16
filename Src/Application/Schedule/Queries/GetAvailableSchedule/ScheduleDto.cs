using System;
using System.Collections.Generic;
using System.Text;

namespace PestSchedule.Application.Schedule.Queries.GetAvailableSchedule
{
    public class ScheduleDto
    {
        public ScheduleDto()
        {
            Veterinaries = new List<ScheduleVeterinaryDto>();
        }
        public IList<ScheduleVeterinaryDto> Veterinaries { get; set; }
    }

    public class ScheduleVeterinaryDto 
    { 
        public int Id { get; set; }
        public string Name{ get; set; }

        public IList<ScheduleAgendaDto> Agenda { get; set; }
    }

    public class ScheduleAgendaDto
    {
        public string Hour { get; set; }

        public DateTime Date { get; set; }
        public bool Available { get; set; }
    }


}
