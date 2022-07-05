using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Services.Interface;
using SqlModels.Repository;
using SqlModels.Repository.Interface;

namespace Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public readonly IRepository<TEntity> _repository;
        public BaseService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public virtual void Create(TEntity TEntity)
        {
            _repository.Create(TEntity);
            _repository.SaveChanges();
        }

        public virtual void Delete(TEntity TEntity)
        {
            _repository.Delete(TEntity);
            _repository.SaveChanges();
        }

        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity TEntity)
        {
             _repository.Update(TEntity);
            _repository.SaveChanges();
        }
    }
}