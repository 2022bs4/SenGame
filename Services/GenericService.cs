using System;
using Services.Interface;
using SqlModels.Repository;
using SqlModels.Repository.Interface;
using SqlModels.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class GenericService<TdbModel> : IService<TdbModel>
        where TdbModel : class
    {
        private readonly IRepository<TdbModel> _repository;
        public GenericService(DbContext context)
        {
            _repository = new GenericRepository<TdbModel>(context);
        }

        public void Create(TdbModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TdbModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TdbModel> GetAll()
        {
            return _repository.GetAll();
        }

        public TdbModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TdbModel entity)
        {
            throw new NotImplementedException();
        }
    }
}