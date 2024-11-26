using Application.DTO;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Producto
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public int Tipo_Producto_Venta_Id { get; set; }
        public bool Activo { get; set; }

        public Tipo_Producto_Venta Tipo_Producto_Venta { get; set; }

    }
}