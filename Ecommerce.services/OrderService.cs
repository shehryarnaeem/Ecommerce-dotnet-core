using Ecommerce.models;
using Ecommerce.repositories;
using Ecommerce.repositories.interfaces;
using Ecommerce.services.interfaces;
namespace Ecommerce.services
{
    public class OrderService : Service<ecommerceContext, Order, OrderRepository>, IOrderService
    {
        public OrderService(IUnitOfWork<ecommerceContext> unitOfWork, OrderRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}