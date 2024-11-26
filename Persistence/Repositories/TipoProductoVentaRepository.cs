using Application.DTO;
using Application.Interface.Persistence;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TipoProductoVentaRepository : ITipoProductoVentaRepository
    {
        private readonly ApplicationDbContext _appcontext;

        public TipoProductoVentaRepository(ApplicationDbContext appcontext)
        {
            _appcontext = appcontext;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<Tipo_Producto_VentaDto>> GetAllAsync()
        {
            var tipoProductoVenta = await _appcontext.Tipo_Producto_Venta
            .ToListAsync();

            return tipoProductoVenta.Select(p => new Tipo_Producto_VentaDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Tipo_Inventario_Id=p.Tipo_Inventario_Id,
                Inventario_Id=p.Inventario_Id,
                Costo= p.Costo,
            }).ToList();
        }

        public Task<IEnumerable<Tipo_Producto_VentaDto>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string productName)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<Tipo_Producto_VentaDto>> GetAsync(int id = 0)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Tipo_Producto_VentaDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Tipo_Producto_VentaDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
