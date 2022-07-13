using Services.Interface;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class BaseService : IBaseService
    {
        private readonly IRepository _Repository;

        //DI注入Repository
        public BaseService(IRepository repository)
        {
            this._Repository = repository;
        }
        public IRepository Repository { get { return _Repository; } }
        //提供外部調用DbContext
        public virtual void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Create<TEntity>(entity);
            Repository.SaveChanges();
        }


        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Update<TEntity>(entity);
            Repository.SaveChanges();
        }
        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Delete<TEntity>(entity);
            Repository.SaveChanges();
        }

        public IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _Repository.FindBy<TEntity>(predicate);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _Repository.GetAll<TEntity>();
        }
    }
}