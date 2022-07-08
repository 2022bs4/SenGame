using SqlModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlModels.Repository.Interface
{
    public interface IRepository : IDisposable 
    {
        public SenGameContext DbContext { get; }

        //Insert New TEntity
        void Create<TEntity>(TEntity entity) where TEntity : class;
        //Edit TEntity
        void Update<TEntity>(TEntity entity) where TEntity : class;
        //Remove Delete
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        //use predicate with variable filter TEntity
        IQueryable<TEntity> FindBy<TEntity>() where TEntity : class;
        //Get All TEntity return IQueryable's Collections
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

        //Save to TEntitybase
        void SaveChanges();
    }
}
