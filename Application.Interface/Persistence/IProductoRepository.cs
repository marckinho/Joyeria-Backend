using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using Domain.Entities;

namespace Application.Interface.Persistence
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        Task<bool> UpdateAsync(ProductoDto producto);
    }
}
