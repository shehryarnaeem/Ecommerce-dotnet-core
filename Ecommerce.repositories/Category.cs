using Ecommerce.models;
namespace Ecommerce.repositories
{
    public class CategoryRepository : BaseRepository<Category, ecommerceContext>
    {
        public CategoryRepository(ecommerceContext context) : base(context)
        {

        }
    }
}