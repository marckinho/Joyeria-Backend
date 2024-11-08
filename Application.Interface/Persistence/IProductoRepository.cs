using Aplication.Interface.Persistence;
using Application.DTO;
using Domain.Entities;

namespace Application.Interface.Persistence
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        //Task<bool> InsertAsync(Producto producto);
        Task<IEnumerable<ProductoDto>> GetAllAsync();
    }
}
