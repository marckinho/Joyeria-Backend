using Application.DTO.ProductosDto;
using Application.Interface.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Data;

namespace Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository 
    {
        private readonly ApplicationDbContext _appcontext;

        public ProductoRepository(ApplicationDbContext appcontext)
        {
            _appcontext = appcontext;
        }

        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int productoId)
        {
            var producto = await _appcontext.Productos.FindAsync(productoId);

            if (producto == null)
            {
                return false;
            }

            _appcontext.Productos.Remove(producto);
            await _appcontext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Producto producto)
        {
            var productoExistente = await _appcontext.Productos.FindAsync(producto.Id);

            if (productoExistente == null)
            {
                return false;  
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Tipo_Producto_Venta_Id = producto.Tipo_Producto_Venta_Id;
            productoExistente.Activo = producto.Activo;

            _appcontext.Update(productoExistente);

            await _appcontext.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<ListaProductosDto>> GetAsync(int id)
        {
            var productos = await _appcontext.Productos
            .Include(p => p.Tipo_Producto_Venta)
            .ToListAsync();

            if(id>0)
                productos = productos.Where(p => p.Id == id).ToList();

            return productos.Select(p => new ListaProductosDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Activo = p.Activo,
                Tipo_Producto_Venta_Id = p.Tipo_Producto_Venta.Id,
                Tipo_Producto_Venta_Nombre = p.Tipo_Producto_Venta.Nombre
            }).ToList();
        }

        public Task<IEnumerable<Producto>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Producto producto)
        {
            await _appcontext.AddAsync(producto);

            return true;
        }

        public Task<IEnumerable<ListaProductosDto>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
