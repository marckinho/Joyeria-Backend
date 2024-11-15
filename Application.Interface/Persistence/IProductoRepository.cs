using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using Domain.Entities;

namespace Application.Interface.Persistence
{
    public interface IProductoRepository : IGenericRepository<ProductoDto>
    {
        /*Task<IEnumerable<ProductoDto>> GetAsync(int id=0);
        Task<IEnumerable<ProductoDto>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string productName);*/
    }
}
