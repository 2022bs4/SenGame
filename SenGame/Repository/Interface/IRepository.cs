using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SenGame.Data;
using SqlModels.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SenGame.Repository
{
    public interface IRepository<TdbModel> : IDisposable
        where TdbModel : class
    {
        //Insert New DATA return ID
        public int Create(TdbModel entity);
        //Edit DATA
        public void Update(TdbModel entity);
        //Remove Delete return ID
        public int Delete(int _Id);
        //use predicate with variable filter data
        public IQueryable<TdbModel> FindBy(Expression<Func<TdbModel, bool>> predicate);
        //Get All DATA return IQueryable's Collections
        public IQueryable<TdbModel> GetAll();
        //Get DATA whit ID return IQueryable's Collections
        public TdbModel GetById(int _Id);
        //Save to database
        public void SaveChanges();
    }
}
