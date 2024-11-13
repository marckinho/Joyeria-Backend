using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Interface.Persistence
{
    public interface IGenericRepository<T> where T: class
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

        //Task<T> GetAsync(int id);
        //Task<IEnumerable<T>> GetAsync();

        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize);

        Task<int> CountAsync();
    }
}
