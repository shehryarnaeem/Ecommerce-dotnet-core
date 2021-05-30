using Ecommerce.models;
namespace Ecommerce.repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem, ecommerceContext>
    {
        public OrderItemRepository(ecommerceContext context) : base(context)
        {

        }
    }
}