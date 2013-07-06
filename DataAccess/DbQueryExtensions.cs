using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public static class DbQueryExtensions
    {
        public static IQueryable<T> Include<T>(this DbQuery<T> source, params Expression<Func<T, object>>[] properties)
        {
            var queryset = source;

            foreach (var property in properties)
            {
                queryset = (DbQuery<T>)queryset.Include(property);
            }

            return queryset;
        }
    }
}