using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// <summary>
    /// Class for mathematics utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170714    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class MathematicsUtils
    {
        /// <summary>
        /// Gets the value represented by a given percentage.
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="percentage">The percentage </param>
        /// <returns> The value represented by the given percentage. </returns>
        public static decimal GetValueByPercentage(decimal value, decimal percentage)
        {
            try
            {
                return value * percentage / 100;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///Converts a given size in Kilobytes to Megabytes.
        /// </summary>
        /// <param name="kbSize">The Kilobytes size</param>
        /// <returns> The Megabytes size representing the given Kilobytes size. </returns>
        public static int ToMegabytes(int kbSize)
        {
            try
            {
                return kbSize / (1024 * 1024);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
