using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.Pages;

namespace VenturaITC.DSMSystem
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Iniatilize log4net
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Code that runs when an unhandled error occurs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Error(object sender, EventArgs e)
        {
            // Get the exception object.
            Exception ex = Server.GetLastError();

            if (ex == null)
            {
                return;
            }

            if (ex.GetType() == typeof(HttpUnhandledException))
            {
                if (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
            }

            Pages.Error.errorMsg = ex.Message + Environment.NewLine + ex.StackTrace;

            //Log the error
            GeneralUtils.LogError(ex.Message, ex);

            //Redirect to error page
            Response.Redirect(AppConstants.Page.ERROR);

            // Clear the error from the server
            Server.ClearError();
        }
    }
}