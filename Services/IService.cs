using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Services
{
    internal interface IService<TEntity> where TEntity : class
    {
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        bool IsExists(int id);
        TEntity GetById(int id);
        public bool Update(int entity);
        IEnumerable<Project> GetAll();
    }
}
