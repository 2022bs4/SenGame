using System;
using System.Linq;
using System.Linq.Expressions;

namespace SqlModels.Repository.Interface
{
    public interface IRepository : IDisposable
    {
        //Insert New DATA
        void Create<TdbModel>(TdbModel data) where TdbModel : class;
        //Edit DATA
        void Update<TdbModel>(TdbModel data) where TdbModel : class;
        //Remove Delete
        void Delete<TdbModel>(TdbModel data) where TdbModel : class;
        //use predicate with variable filter data
        IQueryable<TdbModel> FindBy<TdbModel>(Expression<Func<TdbModel, bool>> predicate) where TdbModel : class;
        //Get All DATA return IQueryable's Collections
        IQueryable<TdbModel> GetAll<TdbModel>() where TdbModel : class;
        //Get DATA whit ID return IQueryable's Collections
        TdbModel GetById<TdbModel>(int _Id) where TdbModel : class;
        //Save to database
        int SaveChanges();
    }
}
