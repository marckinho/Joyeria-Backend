using Application.DTO;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.TipoProductoVenta.Queries.GetAllTipoProductoVentaQuery
{
    public sealed record GetAllTipoProductoVentaQuery : IRequest<Response<IEnumerable<Tipo_Producto_VentaDto>>>
    {
    }
}
