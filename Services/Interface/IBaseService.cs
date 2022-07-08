using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Interface
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Create(TEntity TEntity);
        void Update(TEntity TEntity);
        void Delete(TEntity TEntity);
        bool IsExists(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

    }
}
