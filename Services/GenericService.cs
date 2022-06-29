using System;
using Services.Interface;
using SqlModels.Repository;
using SqlModels.Repository.Interface;
using SqlModels.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class GenericService : IService
    {
        private readonly IRepository _repository;
        public GenericService(IRepository repository)
        {
            this._repository = repository;
        }

        public void Create<TdbModel>(TdbModel data) where TdbModel : class
        {
            throw new NotImplementedException();
        }

        public void Delete<TdbModel>(TdbModel data) where TdbModel : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TdbModel> FindBy<TdbModel>(Expression<Func<TdbModel, bool>> predicate) where TdbModel : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TdbModel> GetAll<TdbModel>() where TdbModel : class
        {
            return _repository.GetAll<TdbModel>();
        }

        public TdbModel GetById<TdbModel>(int id) where TdbModel : class
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Update<TdbModel>(TdbModel data) where TdbModel : class
        {
            throw new NotImplementedException();
        }
    }
}