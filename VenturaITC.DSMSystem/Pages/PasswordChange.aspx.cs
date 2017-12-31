using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.Login.Class;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Changing password page.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170827    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class PasswordChange : MainPage
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

            }
        }

        /// <summary>
        /// Handles the Click event of the btnChangePaswrd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ChangePassword(object sender, EventArgs e)
        {

            try
            {
                if (IsValid)
                {
                    string username = UserUtils.GetLoggedUserName();
                    string oldPassword = txtPassword.Text;
                    string newPassword = txtNewPassword.Text;
                    string newPasswordConfirm = txtNewPasswordConfirm.Text;
                    SignInStatus signInResult = UserUtils.AttemptLogIn(username, txtPassword.Text, shouldLockout: false);

                    switch (signInResult)
                    {
                        case SignInStatus.Success:
                            if (!Validator.ValidatePassword(newPassword))
                            {
                                erroMsg.Text = AppConstants.ErrorMessage.ERROR_INVALID_PASSWORD;
                                ErrorMessage.Visible = true;
                                break;
                            }

                            if (!Validator.PasswordConfirm(newPassword, newPasswordConfirm))
                            {
                                erroMsg.Text = AppConstants.ErrorMessage.ERROR_PASSWORD_CONFIRM;
                                ErrorMessage.Visible = true;
                                break;
                            }

                            if (Validator.IsCurrentPassword(oldPassword, newPassword))
                            {
                                erroMsg.Text = AppConstants.ErrorMessage.ERROR_NEW_PASSWORD_EQUAL_TO_CURRENT;
                                ErrorMessage.Visible = true;
                                break;
                            }

                            UserUtils.ChangePassword(username, txtNewPassword.Text);
                            Response.Redirect(AppConstants.Page.DEFAULT);
                            break;

                        case SignInStatus.IncorrectPassword:
                            erroMsg.Text = AppConstants.ErrorMessage.ERROR_INCORRECT_CURRENT_PASSWORD;
                            ErrorMessage.Visible = true;
                            break;

                        default:
                            erroMsg.Text = AppConstants.InfoMessage.INFO_CHANGE_PASSWORD_FAILURE;
                            ErrorMessage.Visible = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}