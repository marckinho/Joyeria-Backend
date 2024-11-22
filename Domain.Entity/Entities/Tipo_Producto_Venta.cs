using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Tipo_Producto_Venta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Tipo_Inventario_Id { get; set; }
        public int Inventario_Id { get; set; }
        public decimal Costo { get; set; }

        [JsonIgnore]
        public List<Producto> Productos { get; set; } = new List<Producto>();

    }
}
