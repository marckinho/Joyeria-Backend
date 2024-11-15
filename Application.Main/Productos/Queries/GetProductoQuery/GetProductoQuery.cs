using Application.DTO.ProductosDto;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetProductoQuery
{
    public sealed record GetProductoQuery : IRequest<Response<IEnumerable<ProductoDto>>>
    {
        public int Id { get; set; }
    }
}
