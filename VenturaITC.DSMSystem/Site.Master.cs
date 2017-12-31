using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.MODEL.Class;

namespace VenturaITC.DSMSystem
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Force the alert panel hidding.
            pnlAlert.Visible = false;

            if (!IsPostBack)
            {
                //Set the Application info and details.
                lblUsername.Text = Session[AppConstants.SessionVariables.USERNAME].ToString();
                lblFullName.Text = Session[AppConstants.SessionVariables.USER_FULL_NAME].ToString();
                logoImg.ImageUrl = "~/Images/logo.png";
                Page.Header.Title = Properties.Settings.Default.SchoolName;
                lblCopyright.Text = "Copyright © " + DateTime.Now.Year + " - " + Properties.Settings.Default.SchoolName;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
        // <summary>
        /// Shows an alert notification.
        /// </summary>
        /// <param name="message">Thw message to display</param>
        /// <param name="type">The enum type of the message</param>
        public void ShowAlertNotification(string Message, Enumeration.WarningType type)
        {
            try
            {
                switch (type)
                {
                    case Enumeration.WarningType.Success:
                        iconImg.ImageUrl = "~/Images/success.png";
                        lblAlert.Text = "<strong>" + Message + "</strong>";
                        pnlAlert.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
                        pnlAlert.Attributes.Add("role", "alert");
                        pnlAlert.Visible = true;
                        break;

                    case Enumeration.WarningType.Info:
                        iconImg.ImageUrl = "~/Images/info.png";
                        lblAlert.Text = "<strong>" + Message + "</strong>";
                        pnlAlert.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
                        pnlAlert.Attributes.Add("role", "alert");
                        pnlAlert.Visible = true;
                        break;

                    case Enumeration.WarningType.Warning:
                        iconImg.ImageUrl = "~/Images/warning.png";
                        lblAlert.Text = "<strong>" + Message + "</strong>";
                        pnlAlert.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
                        pnlAlert.Attributes.Add("role", "alert");
                        pnlAlert.Visible = true;
                        break;

                    case Enumeration.WarningType.Danger:
                        iconImg.ImageUrl = "~/Images/error.png";
                        lblAlert.Text = "<strong>" + Message + "</strong>";
                        pnlAlert.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
                        pnlAlert.Attributes.Add("role", "alert");
                        pnlAlert.Visible = true;
                        break;

                        //default:
                        //    lblAlert.Text = "<strong>" + Message + "</strong>";
                        //    pnlAlert.CssClass = string.Format("alert alert-{0} alert-dismissable", type.ToString().ToLower());
                        //    pnlAlert.Attributes.Add("role", "alert");
                        //    pnlAlert.Visible = true;
                        //    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Closes the alert panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void CloseAlertPanel(object Source, EventArgs e)
        {
            try
            {
                pnlAlert.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

