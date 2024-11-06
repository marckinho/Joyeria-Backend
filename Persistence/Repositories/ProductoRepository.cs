using Aplication.Interface.Persistence;
using Application.DTO;
using Application.Interface.Persistence;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Data;

namespace Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository 
    {
        private readonly DapperContext _context;
        private readonly ApplicationDbContext _appcontext;


        public ProductoRepository(DapperContext context, ApplicationDbContext appcontext)
        {
            _context = context;
            _appcontext = appcontext;
        }


        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            var productos = await _appcontext.Productos
            .Include(p => p.Tipo_Producto_Venta) // Incluir la relación
            .ToListAsync();

            return productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Activo = p.Activo,
                Tipo_Producto_Venta_Id = p.Tipo_Producto_Venta.Id,
                Tipo_Producto_Venta_Nombre = p.Tipo_Producto_Venta.Nombre
            }).ToList();


            //return productos;
        }

        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(ProductoDto producto)
        {
            throw new NotImplementedException();
        }


        public Task<bool> UpdateAsync(ProductoDto entity)
        {
            throw new NotImplementedException();
        }

        Task<ProductoDto> IGenericRepository<ProductoDto>.GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductoDto>> IGenericRepository<ProductoDto>.GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
