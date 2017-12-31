using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DB.Repository.Class;
using VenturaITC.DSMSystem.BLL.Util;

namespace VenturaITC.DSMSystem.BLL.Unit
{
    /// <summary>
    /// Represents the Unit of Work class.
    /// </summary>
    /// <author> Third Party </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170630   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class UWork<T> : IDisposable where T : class
    {
        private T _entity;
        private List<T> _entityList;
        private Repository<T> _repository;

        public T Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public List<T> EntityList
        {
            get { return _entityList; }
        }

        public UWork(EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS)
        {
            _repository = new Repository<T>(EntityDBUtils.GetContext(dbType));
            _entity = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile().Invoke();
            _entityList = new List<T>();
        }

        public void Save()
        {
            try
            {
                _repository.Add(_entity);
                _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveList()
        {
            try
            {
                foreach (T entity in _entityList)
                {
                    _repository.Add(entity);
                    _repository.Submit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update()
        {
            try
            {
                _repository.Edit(_entity);
                _repository.Submit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateList()
        {
            try
            {
                foreach (T entity in _entityList)
                {
                    _repository.Edit(entity);
                    _repository.Submit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {
            try
            {
                _repository.Remove(_entity);
                _repository.Submit();
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
        public void DeleteBy(Expression<Func<T, bool>> predicate)
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
        /// <param name="dbType">DB type</param>
        public static void DeleteBy(Expression<Func<T, bool>> predicate, EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS)
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
        public static List<T> GetAll(EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS)
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
        /// Get data by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="dbType">DB Type</param>
        /// <returns></returns>
        public static T FindByKey(Object key, EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS)
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
        /// Get list of data by condition
        /// </summary>
        /// <param name="predicate">Condition</param>
        /// <param name="dbType">DB Type</param>
        /// <returns></returns>
        public static List<T> FindBy(Expression<Func<T, bool>> predicate, EntityDBUtils.DBType dbType = EntityDBUtils.DBType.DSMS)
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
            _entity = null;
        }
    }
}
