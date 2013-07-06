using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain
{
    public interface IRepository<TEntity, TId>
        where TEntity : class
    {
        void Delete(TId id);
        void Delete(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(TId id, params Expression<Func<TEntity, object>>[] properties);
        TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties);

        void Insert(TEntity entity);

        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] properties);

        int Save();

//        void Update(TEntity entity);
    }
}