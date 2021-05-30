using Ecommerce.models;
namespace Ecommerce.repositories
{
    public class ProductRepository : BaseRepository<Product, ecommerceContext>
    {
        public ProductRepository(ecommerceContext context) : base(context)
        {

        }
    }
}