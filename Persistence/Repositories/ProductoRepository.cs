using Aplication.Interface.Persistence;
using Application.DTO;
using Application.DTO.ProductosDto;
using Application.Interface.Persistence;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Data;

namespace Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository 
    {
        private readonly ApplicationDbContext _appcontext;
        private readonly IMapper _mapper;

        public ProductoRepository(ApplicationDbContext appcontext,IMapper mapper)
        {
            _appcontext = appcontext;
            _mapper = mapper;
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

        public async Task<IEnumerable<ProductoTipoVentaDto>> GetAsync(int id)
        {
            var productos = await _appcontext.Productos
            .Include(p => p.Tipo_Producto_Venta)
            .ToListAsync();

            if(id>0)
                productos = productos.Where(p => p.Id == id).ToList();

            return productos.Select(p => new ProductoTipoVentaDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Activo = p.Activo,
                Tipo_Producto_Venta = new Tipo_Producto_VentaDto
                {
                    Id = p.Tipo_Producto_Venta.Id,
                    Nombre = p.Tipo_Producto_Venta.Nombre,
                    Tipo_Inventario_Id = p.Tipo_Producto_Venta.Tipo_Inventario_Id,
                    Inventario_Id = p.Tipo_Producto_Venta.Inventario_Id,
                    Costo = p.Tipo_Producto_Venta.Costo
                }
            }).ToList();
        }


        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            var producto = await _appcontext.Productos
            .Include(p => p.Tipo_Producto_Venta)
            .Where(p => p.Activo)
            .ToListAsync();

            return producto;
        }

        public async Task<IEnumerable<Producto>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string productName)
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

            //var productoDto=_mapper.Map<IEnumerable<ProductoDto>>(prods);

            return prods;

        }

        public async Task<bool> InsertAsync(Producto producto)
        {
            await _appcontext.AddAsync(producto);
            return true;
        }

        public Task<bool> UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Producto>> IGenericRepository<Producto>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
