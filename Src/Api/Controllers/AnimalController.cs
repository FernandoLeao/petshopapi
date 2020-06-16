using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PestSchedule.Application.Animal.Commands.CreateAnimal;
using PestSchedule.Application.Animal.Queries.GetAnimalsByCustomerId;

namespace Api.Controllers
{
    public class AnimalController : BaseController
    {
         [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateAnimalCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }


        [HttpGet("{customerId}")]
      
        public async Task<ActionResult<AnimalListVm>> GetByCustomerId(int customerId)
        {
            var vm = await Mediator.Send(new GetAnimalsByCustomerId() { CustomerId = customerId });

            return Ok(vm);
        }
    }
}