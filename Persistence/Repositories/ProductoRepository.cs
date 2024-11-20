using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using Application.Interface.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            int totalProductos = await _appcontext.Productos.CountAsync();
            return totalProductos;
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

        public async Task<bool> UpdateAsync(ProductoDto producto)
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

        public async Task<IEnumerable<ProductoDto>> GetAsync(int id)
        {
            var productos = await _appcontext.Productos
            .Include(p => p.Tipo_Producto_Venta)
            .ToListAsync();

            if(id>0)
                productos = productos.Where(p => p.Id == id).ToList();

            return productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Activo = p.Activo,
                Tipo_Producto_Venta_Id = p.Tipo_Producto_Venta.Id,
                Tipo_Producto_Venta_Nombre = p.Tipo_Producto_Venta.Nombre
            }).ToList();
        }

        public async Task<IEnumerable<ProductoDto>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string productName)
        {

            var productos = _appcontext.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(productName))
            {
                productos = productos.Where(p => p.Nombre.Contains(productName));
                pageNumber = 1;
            }

            var prods = await productos
                .OrderBy(p => p.Nombre)
                .Include(p => p.Tipo_Producto_Venta)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            /*var productos = await _appcontext.Productos
                .Where(p => p.Activo && (string.IsNullOrEmpty(productName) || p.Nombre.Contains(productName)))
                .OrderBy(p => p.Nombre)
                .Include(p => p.Tipo_Producto_Venta)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();*/

            return prods.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Activo = p.Activo,
                Tipo_Producto_Venta_Id = p.Tipo_Producto_Venta.Id,
                Tipo_Producto_Venta_Nombre = p.Tipo_Producto_Venta.Nombre
            }).ToList();
        }

        public async Task<bool> InsertAsync(ProductoDto producto)
        {
            await _appcontext.AddAsync(producto);

            return true;
        }
    }
}
