using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PestSchedule.Application.Schedule.Commands.CreateSchedule;
using PestSchedule.Application.Schedule.Queries.GetAvailableSchedule;

namespace Api.Controllers
{
    public class ScheduleController : BaseController
    {
         [HttpPost]
        public async Task<IActionResult> GetSchedule([FromBody]GetAvailableScheduleQuery query)
        {
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateScheduleCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

    }
}