using Ecommerce.models;
using Ecommerce.repositories;
namespace Ecommerce.services.interfaces
{
    public interface ICategoryService : IService<ecommerceContext, Category, CategoryRepository>
    {

    }
}