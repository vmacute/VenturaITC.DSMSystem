using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DB.Repository.Class;
using VenturaITC.DSMSystem.BLL.Util;

namespace VenturaITC.VenturaITC.DSMSystem.BLL.Unit
{
    /// <summary>
    /// Represents the Unit of Work class.
    /// </summary>
    /// <author> Third Party </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170707   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class GUWork : IDisposable
    {
        private GRepository _repository;
        private dynamic _entity;
        public dynamic Entity
        {
            get { return _entity; }

            set { _entity = value; }
        }

        public void SetEntityType<T>()
        {
            _entity = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile().Invoke();
        }

        public GUWork(EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS)
        {
            _repository = new GRepository(EntityDBUtils.GetContext(dbType));
        }

        public void Save(bool submit = true)
        {
            try
            {
                _repository.Add(Entity);
                if (submit) _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(bool submit = true)
        {
            try
            {
                _repository.Edit(Entity);
                if (submit) _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(bool submit = true)
        {
            try
            {
                _repository.Remove(Entity);
                if (submit) _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        public void DeleteBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                _repository.RemoveBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        public static void DeleteBy<T>(Expression<Func<T, bool>> predicate, EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS) where T : class
        {
            try
            {
                new Repository<T>(EntityDBUtils.GetContext(dbType)).RemoveBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all data from DB
        /// </summary>
        /// <param name="dbType">DB Type</param>
        /// <returns></returns>
        public static List<T> GetAll<T>(EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS) where T : class
        {
            try
            {
                return new Repository<T>(EntityDBUtils.GetContext(dbType)).GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all data from DB
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll<T>() where T : class
        {
            try
            {
                return _repository.GetAll<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get data by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="dbType">DB Type</param>
        /// <returns></returns>
        public static T FindByKey<T>(long key, EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS) where T : class
        {
            try
            {
                return new Repository<T>(EntityDBUtils.GetContext(dbType)).FindByKey(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get data by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="dbType">DB Type</param>
        /// <returns></returns>
        public T FindByKey<T>(long key) where T : class
        {
            try
            {
                return _repository.FindByKey<T>(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get list of data by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <returns></returns>
        public List<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            try
            {
                return _repository.FindBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get list of data by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <param name="dbType">DB Type</param>
        /// <returns></returns>
        public static List<T> FindBy<T>(Expression<Func<T, bool>> predicate, EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS) where T : class
        {
            try
            {
                return new Repository<T>(EntityDBUtils.GetContext(dbType)).FindBy(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _repository.Dispose();
            Entity = null;
        }
    }
}
