using Application.Interface.Persistence;
using Dapper;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DapperContext _context;

        public ProductoRepository(DapperContext context)
        {
            _context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Producto Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Producto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(Producto productos)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "ProductosInsert";
                var parameters = new DynamicParameters();
                //parameters.Add("CustomerId", productos.);
               

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
