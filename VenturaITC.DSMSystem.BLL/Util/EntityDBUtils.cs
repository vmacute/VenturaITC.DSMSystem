using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DSMSystem.DAL.Class;
using VenturaITC.DSMSystem.DAL.Manager;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// <summary>
    /// Represents the Entity Framework database utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170701   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class EntityDBUtils
    {
        /// <summary>
        /// Databases enumerations.
        /// </summary>
        public enum DBType
        {
            DSMS
        }

        /// <summary>
        /// Gets the Entity Framework Database context
        /// </summary>
        /// <param name="dbType">The database type</param>
        /// <returns>The Entity Framework Database context of the given database type.</returns>
        public static DbContext GetContext(DBType dbType = DBType.DSMS, bool lazyLoadingEnabled = true, List<string> navigationProperties = null)
        {
            DbContext ctx;
            try
            {
                switch (dbType)
                {
                    case DBType.DSMS:

                        ctx = new DSMSEntities(DBConnectionManager.GetDSMSEntitiesConnection());
                        break;

                    default:
                        return new DSMSEntities(DBConnectionManager.GetDSMSEntitiesConnection());
                }

                ctx.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

                if (lazyLoadingEnabled) ctx.Configuration.ProxyCreationEnabled = true;
                else
                {
                    if (navigationProperties != null)
                    {
                        foreach (string item in navigationProperties)
                        {
                            ctx.Entry(item);
                        }
                    }
                }

                return ctx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
