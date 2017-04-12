using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGo.Core.Repository
{
    public interface ICoreRepository<T>
    {
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T Insert(T item);
        T Update(T item, Expression<Func<T, bool>> predicate);
        bool Delete(Expression<Func<T, bool>> predicate);
        IEnumerable<T> ExecuteQuery(string commandString, params object[] param);
        List<Dictionary<string, object>> Read(DbDataReader reader);
    }
}
