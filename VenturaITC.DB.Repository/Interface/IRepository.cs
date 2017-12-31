#region Copyright © 2017, Ventura IT & Consulting
//
// Copyright © 2017, Ventura IT & Consulting
// All rights reserved
// http://www.venturaitc.co.mz
//
#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VenturaITC.DB.Repository.Interface
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
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T entity);

        void Remove(T entity);

        void Edit(T entity);

        void Submit();

        List<T> GetAll();

        List<T> FindBy(Expression<Func<T, bool>> predicate);

        T FindByKey(Object key);
    }
}
