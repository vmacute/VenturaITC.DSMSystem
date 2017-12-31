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
    /// user registration page.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170828    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class UserRegistration : MainPage
    {
        /// <summary>
        /// Handles the Load event of the Page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;

            if (!IsPostBack)
            {
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.USER_REGISTRATION);
                BindDdlRole();

            }
        }

        /// <summary>
        /// Binds the ddlStudentType ddlRole control.
        /// </summary>
        private void BindDdlRole()
        {
            try
            {
                List<user_role> pList = UWork<user_role>.GetAll().OrderBy(o => o.name).ToList();

                ddlRole.Items.Clear();

                ddlRole.DataSource = pList;
                ddlRole.DataValueField = "name";
                ddlRole.DataTextField = "description";
                ddlRole.DataBind();

                ddlRole.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void SaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (!StringUtils.IsFullNameValid(txtFullName.Text))
                    {
                        ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_INVALID_USER_FULLNAME, Enumeration.WarningType.Danger);
                        return;
                    }

                    if (UserUtils.ExistsOrActiveUser(txtUsername.Text))
                    {
                        ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_ALREADY_EXISTS_USERNAME, Enumeration.WarningType.Danger);
                        return;
                    }

                    using (UWork<user> work = new UWork<user>())
                    {
                        work.Entity.username = txtUsername.Text;
                        work.Entity.full_name = txtFullName.Text;
                        work.Entity.cell_phone = txtCellPhone.Text;

                        if (txtEmail.Text != string.Empty)
                        {
                            work.Entity.email = txtEmail.Text;
                        }

                        work.Entity.role = ddlRole.SelectedValue;
                        work.Entity.locked = false;
                        work.Entity.disabled = false;
                        work.Entity.password = Security.HashPassword(txtUsername.Text, txtPassword.Text);
                        work.Entity.must_change_password = true;
                        work.Entity.logged = false;
                        work.Entity.current_login_attempts = 0;
                        work.Entity.registration_date = DateTime.Now;
                        work.Entity.registration_user = UserUtils.GetLoggedUserName();
                        work.Entity.status = Enumeration.DatabaseDataStatus.ACTIVE.ToString();
                        work.Save();
                    }

                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event  of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(Request.RawUrl);
            }

            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// Handles the Click event of the btnBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(AppConstants.Page.USER_MANAGER);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}