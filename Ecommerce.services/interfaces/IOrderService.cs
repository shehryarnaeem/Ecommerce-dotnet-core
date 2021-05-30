using Ecommerce.models;
using Ecommerce.repositories;
namespace Ecommerce.services.interfaces
{
    public interface IOrderService: IService<ecommerceContext, Order, OrderRepository>
    {

    }
}