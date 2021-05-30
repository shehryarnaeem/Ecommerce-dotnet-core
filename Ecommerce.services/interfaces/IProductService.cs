using Ecommerce.models;
using Ecommerce.repositories;
namespace Ecommerce.services.interfaces
{
    public interface IProductService: IService<ecommerceContext, Product, ProductRepository>
    {
         
    }
}