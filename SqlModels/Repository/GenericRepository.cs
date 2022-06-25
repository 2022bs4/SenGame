//using System;
////using SenGame.Models;
//using Microsoft.EntityFrameworkCore;
//using SenGame.Repository.Interface;
//using System.Linq;
//using System.Linq.Expressions;

//namespace SenGame.Repository
//{
//    public class GenericRepository<TEntity> : IRepository<TEntity>
//        where TEntity : class
//    {
//        private DbContext _context
//        {
//            get;
//            set;
//        }

//        //public GenericRepository() : this(new SenGameContext())
//        //{

//        //}

//        public GenericRepository(DbContext context)
//        {
//            if (context == null)
//            {
//                throw new ArgumentNullException("context");
//            }
//            _context = context;
//        }

//        public void Create(TEntity entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }
//            else
//            {
//                _context.Set<TEntity>().Add(entity);
//                SaveChanges();
//            }
//        }

//        public void Update(TEntity entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }
//            else
//            {
//                _context.Entry(entity).State = EntityState.Modified;
//                SaveChanges();
//            }
//        }

//        public void Delete(TEntity entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }
//            else
//            {
//                _context.Entry(entity).State = EntityState.Deleted;
//                SaveChanges();
//            }
//        }
//        public TEntity Read(Expression<Func<TEntity, bool>> predicate)
//        {
//            return _context.Set<TEntity>().FirstOrDefault(predicate);
//        }

//        public IQueryable<TEntity> ReadAll()
//        {
//            return _context.Set<TEntity>().AsQueryable();
//        }

//        public void SaveChanges()
//        {
//            _context.SaveChanges();
//        }

//        public void Dispose()
//        {
//            this.Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        //連接操作後進行手動的回收
//        protected virtual void Dispose(bool disposing)
//        {
//            //如果能被回收釋放
//            if (disposing)
//            {
//                //如果有要回收釋放的資源
//                if (_context != null)
//                {
//                    //調用方法回收
//                    _context.Dispose();
//                    _context = null;
//                }
//            }
//        }
//    }
//}
