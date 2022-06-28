using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Interface
{
    public interface IService
    {
        void Create<TdbModel>(TdbModel data) where TdbModel : class;
        void Update<TdbModel>(TdbModel data) where TdbModel : class;
        void Delete<TdbModel>(TdbModel data) where TdbModel : class;
        bool IsExists(int id);
        TdbModel GetById<TdbModel>(int id) where TdbModel : class;
        IQueryable<TdbModel> FindBy<TdbModel>(Expression<Func<TdbModel, bool>> predicate) where TdbModel : class;

        IQueryable<TdbModel> GetAll<TdbModel>() where TdbModel : class;
    }
}
