using SqlModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SqlModels.Repository.Interface
{
    public interface IRepository
    {
        public SenGameContext DbContext { get; }

        //新增單筆資料    無回傳
        void Create<TEntity>(TEntity entity) where TEntity : class;
        
        //更改單筆資料    無回傳
        void Update<TEntity>(TEntity entity) where TEntity : class;
        
        //刪除單筆資料    無回傳
        void Delete<TEntity>(TEntity entity) where TEntity : class;


        //查詢全部資料    回傳IQueryable<T>
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

        //依據條件查詢資料    IQueryable<T>
        IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        
        //將對物件的動作儲存到資料庫    無回傳
        void SaveChanges();
    }
}
