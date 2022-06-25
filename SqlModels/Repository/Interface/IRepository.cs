using System;
using System.Linq;
using System.Linq.Expressions;

namespace SqlModels.Repository.Interface
{
        public interface IRepository<TEntity> : IDisposable
        where TEntity : class
        {
            public void Create(TEntity entity);
            public void Update(TEntity entity);
            public void Delete(TEntity entity);
            //use predicate variable filter data
            public TEntity Read(Expression<Func<TEntity, bool>> predicate);
            public IQueryable<TEntity> ReadAll();
            public void SaveChanges();
        }
}
