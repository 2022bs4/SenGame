using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Services.Interface
{
    public interface IService<TdbModel> where TdbModel : class
    {
        void Create(TdbModel entity);
        void Update(TdbModel entity);
        void Delete(TdbModel entity);
        bool IsExists(int id);
        TdbModel GetById(int id);
        IEnumerable<TdbModel> GetAll();
    }
}
