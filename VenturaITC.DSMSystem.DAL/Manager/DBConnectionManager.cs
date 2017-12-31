using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DSMSystem.MODEL.Class;

namespace VenturaITC.DSMSystem.DAL.Manager
{
    /// <summary>
    /// Represents the Database connection manager class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170701   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class DBConnectionManager
    {
        /// <summary>
        /// Gets the dsms Entity Framework connection string.
        /// </summary>
        /// <returns>The DSM Entity Framework connection string</returns>
        public static string GetDSMSEntitiesConnection()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[AppConstants.ConnectionString.DSMS_ENTITY].ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
