#region Copyright © 2017, Ventura IT & Consulting
//
// Copyright © 2017, Ventura IT & Consulting
// All rights reserved
// http://www.venturaitc.co.mz
//
#endregion

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using VenturaITC.DB.Repository.Interface;

namespace VenturaITC.DB.Repository.Class
{
    /// <summary>
    /// Represents the Repository class.
    /// </summary>
    /// <author> Cipriano Fernandes </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170630   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {

        private DbContext _dbContext;

        public Repository()
        {
            this._dbContext = null;
        }

        public Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList<T>();
        }

        public T FindByKey(Object key)
        {
            return _dbContext.Set<T>().Find(key);
        }

        public List<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dbContext.Set<T>().Where(predicate).ToList<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Add(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Set<T>().Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                string paramName = predicate.Parameters[0].Name;

                string where = new QueryTranslator().Translate(predicate).Replace(paramName + ".", "");

                string table = typeof(T).Name;

                string delete = String.Format("DELETE FROM {0} WHERE {1}", table, where);

                _dbContext.Database.ExecuteSqlCommand(delete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Edit(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Submit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}