using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ProductosDto
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tipo_Producto_Venta_Id { get; set; }
        public bool Activo { get; set; }
        public Tipo_Producto_VentaDto Tipo_Producto_Venta { get; set; }
    }
}
