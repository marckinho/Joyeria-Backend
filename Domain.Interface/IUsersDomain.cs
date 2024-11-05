using Domain.Entity;

namespace Infraestructure.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
