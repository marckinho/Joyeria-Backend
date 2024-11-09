using Domain.Entities;

namespace Aplication.Interface.Persistence
{
    public interface IUsuariosRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> Authenticate(string userName, string pwd);
    }
}
