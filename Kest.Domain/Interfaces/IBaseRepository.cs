using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Kest.Domain.Models;

namespace Kest.Domain.Interfaces
{

    public interface IBaseRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        IEnumerable<TEntity> GetAll();
        PageEnumerable<TEntity> GetPage(int page, int pageSize);
        TEntity GetById(TKey id);

        void Remove(TEntity item);
        void Save(TEntity item);


        //Task<TEntity> QueryById(object id);
        //Task<List<TEntity>> QueryByIds(object[] ids);

        //Task<int> Add(TEntity model);

        //Task<bool> DeleteById(object id);

        //Task<bool> Delete(TEntity model);

        //Task<bool> DeleteByIds(object[] ids);

        //Task<bool> Update(TEntity model);
        //Task<bool> Update(TEntity entity, string strWhere);

        //Task<bool> Update(TEntity entity, List<string> columns = null, List<string> ignoreColumns = null, string strWhere = "");

        //Task<List<TEntity>> Query();
        //Task<List<TEntity>> Query(string strWhere);
        //Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
        //Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, string strOrderByFileds);
        //Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, object>> orderByExpression, bool isAsc = true);
        //Task<List<TEntity>> Query(string strWhere, string strOrderByFileds);

        //Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression, int intTop, string strOrderByFileds);
        //Task<List<TEntity>> Query(string strWhere, int intTop, string strOrderByFileds);

        //Task<List<TEntity>> Query(
        //    Expression<Func<TEntity, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);
        //Task<List<TEntity>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);


        //Task<List<TEntity>> QueryPage(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
        //int SaveChanges();
    }
}
