using ApplicationUseCases.Productos.Commands.CreateProductoCommand;
using ApplicationUseCases.Productos.Commands.DeleteProductoCommand;
using ApplicationUseCases.Productos.Commands.UpdateProductoCommand;
using ApplicationUseCases.Productos.Queries.GetAllProductoQuery;
using ApplicationUseCases.Productos.Queries.GetAllWithPaginationProductoQuery;
using ApplicationUseCases.Productos.Queries.GetProductoQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("Update/{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] UpdateProductoCommand command)
        {
            var productoDto = await _mediator.Send(new GetProductoQuery() { Id = Id });

            if (productoDto.Data == null)
                return NotFound(productoDto.Message);

            if (command == null)
                return BadRequest();

            var response = await _mediator.Send(command);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{productoId}")]
        public async Task<IActionResult> Delete([FromRoute] int productoId)
        {
            if (productoId <= 0)
                return BadRequest();

            var response = await _mediator.Send(new DeleteProductoCommand() { productoId = productoId });

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{productoId}")]
        public async Task<IActionResult> Get([FromRoute] int productoId)
        {
            if (productoId <= 0)
                return BadRequest();

            var response = await _mediator.Send(new GetProductoQuery() { Id = productoId });

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    return Ok(response);
                }
                else
                    return NotFound(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllProductoQuery());

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllPaginated")]
        public async Task<IActionResult> GetAllPaginated([FromQuery] int pageNumber, int pageSize,string productName)
        {
            var response = await _mediator.Send(new GetAllPaginatedProductoQuery() { PageNumber = pageNumber, PageSize = pageSize, ProductName=productName });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
