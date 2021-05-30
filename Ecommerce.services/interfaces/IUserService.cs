using Ecommerce.models;
using Ecommerce.repositories;
namespace Ecommerce.services.interfaces
{
    public interface IUserService : IService<ecommerceContext, User, UserRepository>
    {
        User GetUserByEmail(string email);
    }
}