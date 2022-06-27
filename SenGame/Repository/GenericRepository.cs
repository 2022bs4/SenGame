using System;
//using SenGame.Models;
using Microsoft.EntityFrameworkCore;
using SenGame.Repository;
using System.Linq;
using System.Linq.Expressions;
using SqlModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SenGame.Data;

namespace SenGame.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public SenGameContext Context
        {
            get;
            set;
        }

        //public GenericRepository()
        //{

        //}

        public GenericRepository(SenGameContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
        }

        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                Context.Set<TEntity>().Add(entity);
                SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                Context.Entry(entity).State = EntityState.Modified;
                SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            else
            {
                Context.Entry(entity).State = EntityState.Deleted;
                SaveChanges();
            }
        }
        public TEntity GetById(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        //連接操作後進行手動的回收
        protected virtual void Dispose(bool disposing)
        {
            //如果能被回收釋放
            if (disposing)
            {
                //如果有要回收釋放的資源
                if (Context != null)
                {
                    //調用方法回收
                    Context.Dispose();
                    Context = null;
                }
            }
        }
    }
}
