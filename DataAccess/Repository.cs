using System;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using Domain;

namespace DataAccess
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        private readonly DbContext _context;
        private readonly bool _isSharedContext;

        public Repository(DbContext context, bool isSharedContext = true)
        {
            Contract.Requires(context != null);

            _context = context;
            _isSharedContext = isSharedContext;
        }


        public void Dispose()
        {
            // If this is a shared (or null) context then
            // we're not responsible for disposing it
            if (_isSharedContext || _context == null)
                return;

            _context.Dispose();
        }


        public void Delete(TId id)
        {
            Contract.Requires(id != null);

            var instance = Find(id);
            Delete(instance);
        }

        public void Delete(TEntity instance)
        {
            Contract.Requires(instance != null);

            if (instance != null)
                _context.Set<TEntity>().Remove(instance);
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            Contract.Requires(predicate != null);

            var entities = Query().Where(predicate);

            int entityCount = entities.Count();

            foreach (var entity in entities)
            {
                Delete(entity);
            }

            return entityCount;
        }


        public TEntity Find(TId id, params Expression<Func<TEntity, object>>[] properties)
        {
            Contract.Requires(id != null);

            var instance = _context.Set<TEntity>().Find(id);
            return instance;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties)
        {
            Contract.Requires(predicate != null);

            var instance = _context.Set<TEntity>().Include(properties).SingleOrDefault(predicate);
            return instance;
        }

        public void Insert(TEntity entity)
        {
            Contract.Requires(entity != null);

            _context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] properties)
        {
            var items = _context.Set<TEntity>().Include(properties);
            return items;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}