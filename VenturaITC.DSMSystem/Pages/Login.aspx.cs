using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;
using VenturaITC.Login.Class;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Login page.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170827    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[AppConstants.SessionVariables.USERNAME] != null)
                {
                    string username = Session[AppConstants.SessionVariables.USERNAME].ToString();

                    user user = UserUtils.GetUser(username);
                    user.logged = false;
                    UserUtils.UpdateUser(user);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    SignInStatus signInResult = UserUtils.AttemptLogIn(txtUsername.Text, txtPassword.Text, shouldLockout: true);

                    switch (signInResult)
                    {
                        case SignInStatus.Success:
                            UserUtils.SetUserSessionData(txtUsername.Text);

                            user user = UserUtils.GetUser(txtUsername.Text);
                            user.logged = true;
                            UserUtils.UpdateUser(user);

                            if (UserUtils.MustChangePassword(txtUsername.Text))
                            {
                                Response.Redirect(AppConstants.Page.PASSWORD_CHANGE);
                                break;
                            }

                            Response.Redirect(AppConstants.Page.DEFAULT);
                            break;

                        case SignInStatus.InvalidUserName:
                            erroMsg.Text = AppConstants.ErrorMessage.ERROR_INVALID_USERNAME;
                            ErrorMessage.Visible = true;
                            break;

                        case SignInStatus.IncorrectPassword:
                            erroMsg.Text = AppConstants.ErrorMessage.ERROR_INCORRECT_PASSWORD;
                            ErrorMessage.Visible = true;
                            break;

                        case SignInStatus.LockedOut:
                            erroMsg.Text = AppConstants.InfoMessage.INFO_USER_LOCKEDOUT;
                            ErrorMessage.Visible = true;
                            break;

                        case SignInStatus.Disabled:
                            erroMsg.Text = AppConstants.InfoMessage.INFO_USER_DISABLED;
                            ErrorMessage.Visible = true;
                            break;

                        default:
                            erroMsg.Text = AppConstants.InfoMessage.INFO_LOGIN_FAILURE;
                            ErrorMessage.Visible = true;
                            break;
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}