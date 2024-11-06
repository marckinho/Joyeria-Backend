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

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Usuario> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<Usuario> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Usuario entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> InsertAsync(Usuario entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Usuario entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Usuario entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
