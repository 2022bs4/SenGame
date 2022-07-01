using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using SqlModels.Repository.Interface;
using SqlModels.Data;
using System.Collections.Generic;

namespace SqlModels.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private SenGameContext _context;
        public GenericRepository(SenGameContext context)
        {
            this._context = context;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        //連接操作後進行手動的回收
        public void Dispose(bool disposing)
        {
            //如果能被回收釋放
            if (disposing)
            {
                //如果有要回收釋放的資源
                if (_context != null)
                {
                    //調用方法回收
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        public int SaveChanges()
        {
            int result = _context.SaveChanges();
            return result;
        }

        public void Create(TEntity TEntity)
        {
            _context.Entry(TEntity).State = EntityState.Added;
            _context.Set<TEntity>().Add(TEntity);
        }

        public void Update(TEntity TEntity)
        {
            _context.Entry(TEntity).State = EntityState.Modified;
        }

        public void Delete(TEntity TEntity)
        {
            _context.Entry(TEntity).State = EntityState.Deleted;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int _Id)
        {
            return _context.Set<TEntity>().Find(_Id);
        }
    }
}
