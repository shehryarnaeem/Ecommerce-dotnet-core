using Ecommerce.models;
using Ecommerce.services.interfaces;
using Ecommerce.repositories;
using Ecommerce.repositories.interfaces;
namespace Ecommerce.services
{
    public class CategoryService: Service<ecommerceContext, Category, CategoryRepository>, ICategoryService
    {
        public CategoryService(IUnitOfWork<ecommerceContext> unitOfWork, CategoryRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}