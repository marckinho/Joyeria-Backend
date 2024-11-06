using Application.DTO;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetAllProductoQuery
{
    public sealed record GetAllProductoQuery : IRequest<Response<IEnumerable<ProductoDto>>>
    {
    }
}
