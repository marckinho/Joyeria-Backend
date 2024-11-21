using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public bool Activo { get; set; }
        public int Sucursal_Id { get; set; }
        public int Tipo_Inventario_Id { get; set; }
        public int Valor_Inventario_Id { get; set; }
    }
}
