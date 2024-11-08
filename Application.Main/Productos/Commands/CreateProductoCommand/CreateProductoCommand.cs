using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace ApplicationUseCases.Productos.Commands.CreateProductoCommand
{
    public class CreateProductoCommand : IRequest<Response<bool>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tipo_Producto_Venta_Id { get; set; }
        public bool Activo { get; set; }
    }
}
