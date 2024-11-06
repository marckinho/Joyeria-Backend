using Aplication.Interface.Persistence;
using Application.DTO;
using Domain.Entities;

namespace Application.Interface.Persistence
{
    public interface IProductoRepository : IGenericRepository<ProductoDto>
    {
        Task<bool> InsertAsync(ProductoDto producto);
    }
}
