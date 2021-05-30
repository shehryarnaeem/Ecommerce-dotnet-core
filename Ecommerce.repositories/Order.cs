using Ecommerce.models;
namespace Ecommerce.repositories
{
    public class OrderRepository : BaseRepository<Order, ecommerceContext>
    {
        public OrderRepository(ecommerceContext context) : base(context)
        {

        }
    }
}