using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Interface.Persistence
{
    public interface IGenericRepository<T> where T: class
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);

        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);

        Task<int> CountAsync();
    }
}
