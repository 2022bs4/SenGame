using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SqlModels.Repository.Interface;

namespace Services.Interface
{
    public interface IBaseService
    {
        public IRepository Repository { get; }
        public IMapper Mapper { get; }

        void Create<TEntity>(TEntity entity) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        
        //檢查是否存在
        //public bool CheckIfEntityExistsByEntityId<T>(Expression<Func<T, bool>> expr)
        //{
        //    return _baseRepository.DbSet().Any(u => expr);
        //}
    }
}
