using Ecommerce.services.interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.repositories;
using Ecommerce.repositories.interfaces;
using System.Collections.Generic;

namespace Ecommerce.services
{
    public class Service<TDbContext, TEntity, TRepository> : IService<TDbContext, TEntity, TRepository>
    where TDbContext : DbContext
    where TEntity : class
    where TRepository : BaseRepository<TEntity, TDbContext>
    {
        private readonly IUnitOfWork<TDbContext> _unitOfWork;
        private readonly TRepository _repository;
        public IUnitOfWork<TDbContext> UnitOfWork => _unitOfWork;

        public TRepository Repository => _repository;

        public Service(IUnitOfWork<TDbContext> unitOfWork, TRepository repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public TEntity Create(TEntity entity)
        {
            this._repository.Insert(entity);
            this._unitOfWork.Commit();
            return entity;
        }

        public void Delete(object id)
        {
            this._repository.Delete(id);
            this._unitOfWork.Commit();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._repository.Get();
        }

        public TEntity GetById(object id)
        {
            return this._repository.GetByID(id);
        }

        public void Update(TEntity entity)
        {
            this._repository.Update(entity);
            this._unitOfWork.Commit();
        }
    }
}