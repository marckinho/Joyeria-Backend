using Application.DTO.ProductosDto;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetAllProductoQuery
{
    public sealed record GetAllProductoQuery : IRequest<Response<IEnumerable<ListaProductosDto>>>
    {
    }
}
