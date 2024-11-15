using Aplication.Interface.Persistence;
using Dapper;
using Domain.Entities;
using Persistence.Contexts;
using System.Data;

namespace Persistence.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly DapperContext _context;

        public UsuariosRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Authenticate(string userName,string pwd)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "UsuarioCredenciales";
                var parameters = new DynamicParameters();
                parameters.Add("Usuario", userName);
                parameters.Add("Pwd", pwd);

                var user = await connection.QuerySingleOrDefaultAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return user;
            }
        }

        public async Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllWithPaginationAsync(int pageNumber, int pageSize, string productName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAsync(int id = 0)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
