using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// <summary>
    /// Class for String utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170715    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class StringUtils
    {
        /// <summary>
        /// Indicates whether given full name is valid.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns>true if valid; false otherwise</returns>
        public static bool IsFullNameValid(string fullName)
        {
            try
            {
                string[] names = fullName.Split(' ');
                return names.Length > 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
