using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.ProductosDto;

namespace Application.DTO
{
    public class Tipo_Producto_VentaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tipo_Inventario_Id { get; set; }
        public int Inventario_Id { get; set; }
        public decimal Costo { get; set; }

        public List<ListaProductosDto> Productos { get; set; } = new List<ListaProductosDto>();
    }
}
