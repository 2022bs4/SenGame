using System;
using System.Linq;
using System.Linq.Expressions;

namespace SqlModels.Repository.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        //Insert New TEntity
        void Create(TEntity TEntity);
        //Edit TEntity
        void Update(TEntity TEntity);
        //Remove Delete
        void Delete(TEntity TEntity);
        //use predicate with variable filter TEntity
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        //Get All TEntity return IQueryable's Collections
        IQueryable<TEntity> GetAll();
        //Get TEntity whit ID return IQueryable's Collections
        TEntity GetById(int _Id);
        //Save to TEntitybase
        int SaveChanges();
    }
}
