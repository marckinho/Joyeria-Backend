using ApplicationUseCases.Productos.Queries.GetAllProductoQuery;
using ApplicationUseCases.TipoProductoVenta.Queries.GetAllTipoProductoVentaQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoVentaController : Controller
    {
        private readonly IMediator _mediator;

        public TipoProductoVentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllTipoProductoVentaQuery());

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
