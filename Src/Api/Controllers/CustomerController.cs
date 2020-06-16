using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PestSchedule.Application.Customer.Commands.CreateCustomer;
using PestSchedule.Application.Customer.Queries.GetGustomerByCpf;
using PestSchedule.Application.Customer.Queries.GetGustomerByName;

namespace Api.Controllers
{
    public class CustomerController : BaseController
    {
        [HttpGet("{cpf}")]
        public async Task<ActionResult<CustomerDetailCpfVm>> GetCustomerBycpf(string cpf)
        {
            var vm = await Mediator.Send(new GetCustomerByCpf() { Cpf = cpf});

            return Ok(vm);
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<CustomerListVm>> GetCustomerByName(string name)
        {
            var vm = await Mediator.Send(new GetCustomerByName() { Name = name});

            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}