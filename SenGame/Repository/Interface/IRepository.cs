using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SenGame.Data;
using SqlModels.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SenGame.Repository
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        public void Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        //use predicate variable filter data
        public TEntity GetById(Expression<Func<TEntity, bool>> predicate);
        public IQueryable<TEntity> GetAll();
        public void SaveChanges();
    }
}
