using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplication.Interface.Persistence
{
    public interface IGenericRepository<T> where T: class
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

        //Task<T> GetAsync(int id=0);
        Task<IEnumerable<T>> GetAsync(int id=0);

        Task<IEnumerable<T>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string productName);

        Task<int> CountAsync();
    }
}
