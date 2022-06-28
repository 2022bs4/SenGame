using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Services.Interface
{
    internal interface IService<TdbModel> where TdbModel : class
    {
        bool Create(TdbModel entity);
        bool Update(TdbModel entity);
        bool Delete(TdbModel entity);
        bool IsExists(int id);
        TdbModel GetById(int id);
        public bool Update(int entity);
        IEnumerable<TdbModel> GetAll();
    }
}
