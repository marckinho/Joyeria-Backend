using Aplication.Interface.Persistence;
using Application.Interface.Persistence;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepository Customers { get; }
        public IUsersRepository Users { get; }
        public IDiscountRepository Discounts {  get; }
        public IProductoRepository Productos { get; }

        private readonly ApplicationDbContext _applicationDbContext;

        public UnitOfWork(ICustomersRepository customers,IUsersRepository users,IDiscountRepository discounts, ApplicationDbContext applicationDbContext) 
        {
            Customers = customers;
            Users = users;
            Discounts = discounts;
            _applicationDbContext = applicationDbContext;
        }

        public void Dispose() 
        {
            System.GC.SuppressFinalize(this);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
