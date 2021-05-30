using Ecommerce.repositories.interfaces;
using Ecommerce.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace Ecommerce.repositories
{
    public class UnitOfWork : IUnitOfWork<ecommerceContext>
    {
        private ecommerceContext _dbContext;
        private CategoryRepository _categoryRepository;
        private OrderRepository _orderRepository;
        private OrderItemRepository _orderItemRepository;
        private ProductRepository _productsRepository;
        private UserRepository _userRepository;
        public UnitOfWork(ecommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ??
                    (_categoryRepository = new CategoryRepository(_dbContext));
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??
                    (_orderRepository = new OrderRepository(_dbContext));
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                return _productsRepository ??
                    (_productsRepository = new ProductRepository(_dbContext));
            }
        }

        public OrderItemRepository OrderItemRepository
        {
            get
            {
                return _orderItemRepository ??
                    (_orderItemRepository = new OrderItemRepository(_dbContext));
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                return _userRepository ??
                    (_userRepository = new UserRepository(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

    }
}