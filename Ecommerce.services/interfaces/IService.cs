using Microsoft.EntityFrameworkCore;
using Ecommerce.repositories.interfaces;
using System.Collections.Generic;
using System.Linq;
namespace Ecommerce.services.interfaces
{
    public interface IService<TDbContext, TEntity, TRepository>
    where TDbContext : DbContext
    where TEntity : class
    where TRepository : IRepository<TEntity>
    {
        IUnitOfWork<TDbContext> UnitOfWork { get; }
        TRepository Repository { get; }
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        int Count();
    }
}