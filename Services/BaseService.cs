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
        private readonly IRepository<TEntity> _repository;
        public BaseService(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }

        public void Create(TEntity TEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity TEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity TEntity)
        {
            throw new NotImplementedException();
        }
    }
}