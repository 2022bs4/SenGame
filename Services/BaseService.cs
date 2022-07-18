using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Services.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;
using SqlModels.Models;
using SqlModels.Repository.Interface;

namespace Services
{
    public class BaseService : IBaseService
    {
        private readonly IRepository _Repository;
        private readonly IMapper _Mapper;
        public IRepository Repository { get { return _Repository; } }
        public IMapper Mapper { get { return _Mapper; } }
        //DI注入Repository,Mapper
        public BaseService(IRepository repository, IMapper mapper)
        {
            this._Repository = repository;
            this._Mapper = mapper;
        }

        public BaseService(IRepository repository)
        {
        }

        //提供外部調用DbContext
        public virtual void Create<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Create<TEntity>(entity);
            Repository.SaveChanges();
        }


        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Update<TEntity>(entity);
            Repository.SaveChanges();
        }
        public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _Repository.Delete<TEntity>(entity);
            Repository.SaveChanges();
        }

        public IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _Repository.FindBy<TEntity>(predicate);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _Repository.GetAll<TEntity>();
        }
    }
}