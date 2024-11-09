namespace Application.DTO.ProductosDto
{
    public class ListaProductosDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public int Tipo_Producto_Venta_Id { get; set; }
        public string Tipo_Producto_Venta_Nombre { get; set; }

    }
}
