using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PestSchedule.Application.Veterinary.Queries.GetAllVeterinary;

namespace Api.Controllers
{
    public class VeterinaryController : BaseController
    {
        
        [HttpGet()]      
        public async Task<ActionResult<VeterinaryListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetAllVeterinaryQuery());

            return Ok(vm);
        }
    }
}