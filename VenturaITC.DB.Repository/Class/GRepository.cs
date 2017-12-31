using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DB.Repository.Interface;

namespace VenturaITC.DB.Repository.Class
{
    /// <summary>
    /// Represents the Repository inteface.
    /// </summary>
    /// <typeparam name="T">Class/entity</typeparam>
    /// <author> Cipriano Fernandes </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170630   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class GRepository : IDisposable, IGRepository
    {
        private DbContext _dbContext;

        public DbContext DbContext
        {
            get { return _dbContext; }
            set { _dbContext = value; }
        }

        public GRepository()
        {
            this._dbContext = null;
        }

        public GRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().ToList<T>();
        }

        public List<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dbContext.Set<T>().Where(predicate).ToList<T>();
        }

        public T FindByKey<T>(object key) where T : class
        {
            return _dbContext.Set<T>().Find(key);
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            string paramName = predicate.Parameters[0].Name;

            string where = new QueryTranslator().Translate(predicate).Replace(paramName + ".", "");

            string table = typeof(T).Name;

            string delete = String.Format("DELETE FROM {0} WHERE {1}", table, where);

            _dbContext.Database.ExecuteSqlCommand(delete);
        }

        public void Edit<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Submit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
