using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;

namespace VenturaITC.DSMSystem.BLL.Class
{
    /// <summary>
    /// Permission manager class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170817    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class PermissionManager
    {
        /// <summary>
        /// Checks the user permition.
        /// </summary>
        /// <param name="role">The user's role.</param>
        /// <param name="page">The Page's name</param>
        /// <param name="response">The HttpResponse object</param>
        public static void CheckUserPermition(string role, string page)
        {
            try
            {
                bool accessDenied = false;
                HttpResponse response = HttpContext.Current.ApplicationInstance.Response;


                switch (page)
                {
                    case AppConstants.Page.USER_MANAGER:
                        if (role!=Enumeration.UserRole.ADMINISTRATOR.ToString())
                        {
                            accessDenied = true;
                        }
                        break;

                    default:
                        break;
                }

                if (accessDenied)
                {
                    response.Redirect(AppConstants.Page.ACCESS_DENIED);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
