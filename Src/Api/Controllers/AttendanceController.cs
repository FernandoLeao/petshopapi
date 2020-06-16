using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PestSchedule.Application.Attendance.Commands.CreateAttendance;
using PestSchedule.Application.Attendance.Queries.GetAttendanceByCustomerId;

namespace Api.Controllers
{
    public class AttendanceController : BaseController
    {
         [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateAttendanceCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }


       [HttpGet("{customerId}")]      
        public async Task<ActionResult<AttendanceListVm>> GetByCustomerId(int customerId)
        {
            var vm = await Mediator.Send(new GetAttendanceByCustomerIdQuery() { CustomerId = customerId });

            return Ok(vm);
        }
    }
}