#region Copyright © 2017, Ventura IT & Consulting
//
// Copyright © 2017, Ventura IT & Consulting
// All rights reserved
// http://www.venturaitc.co.mz
//
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VenturaITC.DB.Repository.Interface
{
    /// <summary>
    /// Represents the Group Repository inteface.
    /// </summary>
    /// <author> Cipriano Fernandes </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170707   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public interface IGRepository : IDisposable
    {
        List<T> GetAll<T>() where T : class;

        List<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;

        T FindByKey<T>(object key) where T : class;

        void Add<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;

        void RemoveBy<T>(Expression<Func<T, bool>> predicate) where T : class;

        void Edit<T>(T entity) where T : class;

        void Submit();

    }
}
