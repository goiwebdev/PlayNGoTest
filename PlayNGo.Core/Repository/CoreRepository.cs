using PlayNGo.Core.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlayNGo.Core.Repository
{
    public class CoreRepository<T> : ICoreRepository<T> where T : class
    {
        protected IContext Db;

        public CoreRepository(IContext datacontext)
        {
            Db = datacontext;
        }

        #region IRepository<T> Members

        public T Insert(T item)
        {
            Db.Set<T>().Add(item);
            Db.SaveChanges();
            return item;
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            var list = SearchFor(predicate).ToList();
            if (list != null)
            {
                foreach (T ctr in list)
                {
                    Db.Entry<T>(ctr).State = System.Data.Entity.EntityState.Deleted;
                }

                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public T Update(T item, Expression<Func<T, bool>> predicate)
        {
            var record = SearchFor(predicate).FirstOrDefault();
            if (record != null)
            {
                var init = Db.Entry<T>(record).CurrentValues.ToObject();

                Db.Entry<T>(record).CurrentValues.SetValues(CopyValues(init, item));
                Db.SaveChanges();
                return record;
            }

            return null;
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {

            return Db.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return Db.Set<T>();
        }

        public IEnumerable<T> ExecuteQuery(string commandString, params object[] param)
        {
            return (Db as System.Data.Entity.DbContext).Database.SqlQuery<T>(commandString, param);
        }
        public void ExecuteSQLCommand(string sql, params object[] param)
        {
            (Db as System.Data.Entity.DbContext).Database.ExecuteSqlCommand(sql, param);
        }

        public List<Dictionary<string, object>> Read(DbDataReader reader)
        {
            List<Dictionary<string, object>> expandolist = new List<Dictionary<string, object>>();
            foreach (var item in reader)
            {
                IDictionary<string, object> expando = new ExpandoObject();
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item))
                {
                    var obj = propertyDescriptor.GetValue(item);
                    expando.Add(propertyDescriptor.Name, obj);
                }
                expandolist.Add(new Dictionary<string, object>(expando));
            }
            return expandolist;
        }

        #endregion

        #region static class
        private object CopyValues(object target, T source)
        {
            Type t = typeof(T);

            var properties = t.GetProperties().Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                if (value != null)
                {
                    prop.SetValue(target, value, null);
                }
            }

            return target;
        }
        #endregion

    }
}
