using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.MODEL.Entity;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// <summary>
    /// Represents the student utilities class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170701    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class DateUtils
    {
        /// <summary>
        /// Converts a string to DateTime.
        /// </summary>
        /// <param name="date">The given date string.</param>
        /// <returns>The converted DateTime</returns>
        public static DateTime StringToDate(string date)
        {
            try
            {
                DateTime newDate = DateTime.Parse(date);
                return newDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a date string in the dd-MM-yyyy format.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <returns>The date string in the dd-MM-yyyy format.</returns>
        public static string GetDateString_dd_MM_yyyy(DateTime date)
        {
            try
            {
                return date.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a date string in the dd-MM-yyyy hh:mm:ss format.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <returns>The date string in the dd-MM-yyyy hh:mm:ss format.</returns>
        public static string GetDateString_dd_MM_yyyy_hh_mm_ss(DateTime date)
        {
            try
            {
                return date.ToString("dd/MM/yyyy hh:mm:ss");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a date string in the yyyy/MM/dd format.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <returns>The date string in the yyyy/MM/dd format.</returns>
        public static string GetDateString_yyyy_MM_dd(DateTime date)
        {
            try
            {
                return date.ToString("yyyy/MM/dd");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether one date is after other one.
        /// </summary>
        /// <param name="date1">The first date</param>
        /// <param name="date2">The second date</param>
        /// <returns>true if the first date is after the second date; false otherwise</returns>
        public static bool IsDate1AfterDate2(DateTime date1, DateTime date2)
        {
            try
            {
                return DateTime.Compare(date1, date2) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether a given date is a national holiday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>true if the given date is a national holiday; false otherwise</returns>
        public static bool IsNationalHoliday(DateTime date)
        {
            try
            {
                int _day = date.Day;
                int _month = date.Month;

                List<holiday> holidays = UWork<holiday>.FindBy(x => x.day == _day && x.month == _month);

                if (holidays.Count > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the number of days between two dates.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The number of days between two dates.</returns>
        public static int GetDaysRange(DateTime startDate, DateTime endDate)
        {
            int count = 0;

            try
            {
                for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
                {
                    count += 1;
                }

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the number of working days between two dates.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The number of working days between two dates.</returns>
        public static int GetWorkingDaysRange(DateTime startDate, DateTime endDate)
        {
            int count = 0;

            try
            {
                for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
                {
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !IsNationalHoliday(date))
                    {
                        count += 1;
                    }
                }

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
