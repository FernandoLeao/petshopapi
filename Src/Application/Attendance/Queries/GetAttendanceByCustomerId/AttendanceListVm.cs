using System.Collections.Generic;

namespace PestSchedule.Application.Attendance.Queries.GetAttendanceByCustomerId
{
    public class AttendanceListVm 
    {
        public IList<AttendanceDto> Attendances { get; set; }
    }
}
