using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;

namespace VenturaITC.DSMSystem.Pages
{
    public class MainPage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                if (!IsSuportedBrowser())
                {
                    Response.Redirect(AppConstants.Page.INFO);
                }

                Object username = Session[AppConstants.SessionVariables.USERNAME];
                Object fullNme = Session[AppConstants.SessionVariables.USER_FULL_NAME];
                Object role = Session[AppConstants.SessionVariables.USER_ROLE];

                if (username == null || fullNme == null || role == null)
                {
                    //Session data empty, so redirect to login page.
                    Response.Redirect(AppConstants.Page.LOGIN);
                }

                user user = UserUtils.GetUser(username.ToString());
                if (!user.logged)
                {
                    //user logged out, so redirect to login page.
                    Response.Redirect(AppConstants.Page.LOGIN);
                }
            }
        }

        /// <summary>
        /// Indicates whether the application supports the used browser.
        /// </summary>
        /// <returns>true if the used browser is suppororted; false otherwise</returns>
        private bool IsSuportedBrowser()
        {
            try
            {
                HttpBrowserCapabilities browser = Request.Browser;
                string currentBrowser = browser.Browser;

                List<string> supportedBrowsers = new List<string>();
                supportedBrowsers.Add("Chrome");
                supportedBrowsers.Add("Firefox");

                if (!supportedBrowsers.Contains(currentBrowser))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}