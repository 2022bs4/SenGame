//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.CodeAnalysis;
//using SqlModels.Models;
//namespace Services
//{
//    internal class ArticlesService : IService<Article>
//    {
//        private readonly IRepository<TEnity> repository = new GenericRepository<TEnity>();
//        public void Create(Project entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }
//            else
//            {
//                repository.Create(entity);
//            }
//        }

//        public void Update(Project entity)
//        {
//            if (entity == null)
//            {
//                throw new ArgumentNullException("entity");
//            }
//            else
//            {
//                repository.Update(entity);
//            }
//        }

//        public void Delete(Guid id)
//        {
//            if (!IsExists(id))
//            {

//            }
//            else
//            {
//                var entity = GetById(id);
//                repository.Delete(entity);
//            }
//        }

//        public bool IsExists(Guid id)
//        {
//            return repository.GetAll().Any(x => x.Id == id);
//        }

//        public Project GetById(Guid id)
//        {
//            return repository.Get(x => x.Id == id);
//        }

//        public IEnumerable<Project> GetAll()
//        {
//            return repository.GetAll();
//        }
//    }
//}
