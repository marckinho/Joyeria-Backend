using ApplicationUseCases.Customers.Commands.CreateCustomerCommand;
using ApplicationUseCases.Productos.Commands.CreateProductoCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Services.WebApi.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateProductoCommand command)
        {
            if (command == null)
                return BadRequest();

            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
