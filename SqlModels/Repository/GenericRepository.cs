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
        //連線Db不可變動
        private readonly SenGameContext _DbContext;

        //DI注入DbContext
        public GenericRepository(SenGameContext context)
        {
            this._DbContext = context;
        }
        //提供外部調用DbContext
        public SenGameContext DbContext { get { return _DbContext; } }

        //實作
        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Added;
        }
        

        //實作
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        //實作
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _DbContext.Entry(entity).State = EntityState.Deleted;
        }

        //實作
        public IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _DbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }

        //實作
        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _DbContext.Set<TEntity>().AsQueryable();
        }

        //儲存對於_DbContext的變動到資料庫
        public void SaveChanges()   
        {
             _DbContext.SaveChanges();
        }
    }
}
