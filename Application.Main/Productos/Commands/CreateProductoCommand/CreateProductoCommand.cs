using MediatR;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Commands.CreateProductoCommand
{
    public sealed record CreateProductoCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tipo_Producto_Venta_Id { get; set; }
        public bool Activo { get; set; }
    }
}
