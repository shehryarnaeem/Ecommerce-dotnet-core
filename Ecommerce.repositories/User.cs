using Ecommerce.models;
namespace Ecommerce.repositories
{
    public class UserRepository : BaseRepository<User, ecommerceContext>
    {
        public UserRepository(ecommerceContext context) : base(context) { }
    }
}