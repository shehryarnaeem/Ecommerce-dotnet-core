using Ecommerce.services.interfaces;
using Ecommerce.models;
using Ecommerce.repositories;
using Microsoft.EntityFrameworkCore;
using Ecommerce.repositories.interfaces;
using System.Collections.Generic;

namespace Ecommerce.services
{
    public class ProductService : Service<ecommerceContext, Product, ProductRepository>, IProductService
    {
        public ProductService(IUnitOfWork<ecommerceContext> unitOfWork, ProductRepository repository) : base(unitOfWork, repository)
        {
        }
    }
}