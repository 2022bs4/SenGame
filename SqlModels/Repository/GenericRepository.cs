using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using SqlModels.Repository.Interface;
using SqlModels.Data;
using System.Collections.Generic;

namespace SqlModels.Repository
{
    public class GenericRepository : IRepository
    {
        private SenGameContext _DbContext;

        public GenericRepository(SenGameContext context)
        {
            this._DbContext = context;
        }
        public SenGameContext DbContext { get { return _DbContext; } }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Added;
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            
        }

        public IQueryable<TEntity> FindBy<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _DbContext.Set<TEntity>();
        }

        public void SaveChanges()
        {
             _DbContext.SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
