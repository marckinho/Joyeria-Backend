using Aplication.Interface.Persistence;
using Application.DTO;
using Application.DTO.ProductosDto;
using Domain.Entities;

namespace Application.Interface.Persistence
{
    public interface IProductoRepository : IGenericRepository<ProductoDto>
    {
        public Task<bool> InsertAsync(Producto producto);
        /*Task<IEnumerable<ProductoDto>> GetAsync(int id=0);*/
        Task<IEnumerable<ProductoTipoVentaDto>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string productName);
    }
}
