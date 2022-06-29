using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using SqlModels.Repository.Interface;
using SqlModels.Data;
namespace SqlModels.Repository
{
    public class GenericRepository : IRepository
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

        public void Create<TdbModel>(TdbModel data) where TdbModel : class
        {
            _context.Entry<TdbModel>(data).State = EntityState.Added;
        }

        public void Update<TdbModel>(TdbModel data) where TdbModel : class
        {
            _context.Entry<TdbModel>(data).State = EntityState.Modified;
        }

        public void Delete<TdbModel>(TdbModel data) where TdbModel : class
        {
            _context.Entry<TdbModel>(data).State = EntityState.Deleted;
        }

        public IQueryable<TdbModel> FindBy<TdbModel>(Expression<Func<TdbModel, bool>> predicate) where TdbModel : class
        {
            return _context.Set<TdbModel>().Where(predicate); 
        }

        public IQueryable<TdbModel> GetAll<TdbModel>() where TdbModel : class
        {
            return _context.Set<TdbModel>();
        }

        public TdbModel GetById<TdbModel>(int _Id) where TdbModel : class
        {
            return _context.Set<TdbModel>().Find(_Id);
        }
    }
}
