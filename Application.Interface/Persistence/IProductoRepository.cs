using Aplication.Interface.Persistence;
using Application.DTO.ProductosDto;
using Domain.Entities;

namespace Application.Interface.Persistence
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        Task<IEnumerable<ListaProductosDto>> GetAsync(int id=0);
    }
}
