using Application.DTO.ProductosDto;
using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Queries.GetProductoQuery
{
    public sealed record GetProductoQuery : IRequest<Response<IEnumerable<ListaProductosDto>>>
    {
        public int Id { get; set; }
    }
}
