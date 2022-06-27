using System;
using Microsoft.EntityFrameworkCore;
using SenGame.Repository;
using System.Linq;
using System.Linq.Expressions;
using SqlModels.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SenGame.Data;

namespace SenGame.Repository
{
    public class GenericRepository<TdbModel> : IRepository<TdbModel>
        where TdbModel : class
    {
        public SenGameContext DbContext { get; set; }
        public DbSet<TdbModel> DbSet { get; set; }
        public GenericRepository() : this(new SenGameContext())
        {

        }
        public GenericRepository(SenGameContext context)
        {
            this.DbContext = context;
            this.DbSet = DbContext.Set<TdbModel>();
        }

        public int Create(TdbModel entity)
        {
            dynamic obj = DbSet.Add(entity);
            this.SaveChanges();
            return obj.Id;
        }

        public void Update(TdbModel entity)
        {
            DbSet.Update(entity);
            this.SaveChanges();
        }

        public int Delete(int _Id)
        {
            var item = DbSet.Find(_Id);
            dynamic obj = DbSet.Remove(item);
            this.SaveChanges();
            return obj.Id;
        }

        public IQueryable<TdbModel> FindBy(Expression<Func<TdbModel, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<TdbModel> GetAll()
        {
            return DbSet;
        }

        public TdbModel GetById(int _Id)
        {
            return DbSet.Find(_Id);
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
                if (DbContext != null)
                {
                    //調用方法回收
                    DbContext.Dispose();
                    DbContext = null;
                }
            }
        }
        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
