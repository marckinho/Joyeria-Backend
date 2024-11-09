using Aplication.Interface.Persistence;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _appcontext;


        public ProductoRepository(ApplicationDbContext appcontext)
        {
            _appcontext = appcontext;
        }

        public async Task<IEnumerable<ListaProductosDto>> GetAllAsync()
        {
            var productos = await _appcontext.Productos
            .Include(p => p.Tipo_Producto_Venta) // Incluir la relación
            .ToListAsync();

            return productos.Select(p => new ListaProductosDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Activo = p.Activo,
                Tipo_Producto_Venta_Id = p.Tipo_Producto_Venta.Id,
                Tipo_Producto_Venta_Nombre = p.Tipo_Producto_Venta.Nombre
            }).ToList();

        }

        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Producto producto)
        {
            var productoExistente = await _appcontext.Productos.FindAsync(producto.Id);

            if (productoExistente == null)
            {
                return false;  // No se encontró el producto
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Tipo_Producto_Venta_Id = producto.Tipo_Producto_Venta_Id;
            productoExistente.Activo = producto.Activo;

            await _appcontext.AddAsync(productoExistente);

            return true;

        }

        public Task<Producto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Producto>> IGenericRepository<Producto>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Producto producto)
        {
            await _appcontext.AddAsync(producto);

            return true;
        }
    }
}
