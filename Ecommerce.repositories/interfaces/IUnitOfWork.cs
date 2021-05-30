using Ecommerce.models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.repositories.interfaces
{
    public interface IUnitOfWork<TDbContext> where TDbContext: DbContext
    {
        CategoryRepository CategoryRepository { get; }
        OrderRepository OrderRepository { get; }
        OrderItemRepository OrderItemRepository { get; }
        ProductRepository ProductRepository { get; }
        UserRepository UserRepository { get; }
        void Commit();
    }
}