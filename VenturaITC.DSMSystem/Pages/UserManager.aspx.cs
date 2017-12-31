using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;
using VenturaITC.DSMSystem.Util;
using VenturaITC.Login.Class;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Page for user managment.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170828    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class UserManager : MainPage
    {
        public string Username
        {
            get
            {
                return ViewState["username"].ToString();
            }
            set
            {
                ViewState["username"] = value;
            }
        }

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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.USER_MANAGER);
                BindDdlStatusFilter();
                BindDdlRole();
            }
        }

        /// <summary>
        /// Binds the ddlStatusFilter control.
        /// </summary>
        private void BindDdlStatusFilter()
        {
            try
            {
                List<db_data_status> pList = UWork<db_data_status>.GetAll().OrderBy(o => o.name).ToList();

                ddlStatusFilter.Items.Clear();

                ddlStatusFilter.DataSource = pList;
                ddlStatusFilter.DataValueField = "name";
                ddlStatusFilter.DataTextField = "description";
                ddlStatusFilter.DataBind();

                ddlStatusFilter.Items.Insert(0, new ListItem(AppConstants.General.ALL_TEXT, Enumeration.PaymentStatus.ALL.ToString()));
                ddlStatusFilter.SelectedValue = Enumeration.DatabaseDataStatus.ACTIVE.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlRole control.
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
        /// Handles the OnSelectedIndexChanged of the ddlStatusFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlStatusFilter_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<user> users = UserUtils.GetAllUsers();

                if (ddlStatusFilter.SelectedValue == Enumeration.DatabaseDataStatus.ACTIVE.ToString())
                {
                    users = UserUtils.GetActiveUsers();
                }

                if (ddlStatusFilter.SelectedValue == Enumeration.DatabaseDataStatus.DELETED.ToString())
                {
                    users = UserUtils.GetDeletedUsers();
                }

                rgUsers.DataSource = users;
                rgUsers.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        /// Handles the NeedDataSource event of the rgUsers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
        protected void rgUsers_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgUsers.DataSource = UserUtils.GetActiveUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the ItemCommand of the rgUsers control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void rgUsers_ItemCommand(Object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    string username = ((GridDataItem)e.Item).GetDataKeyValue("username").ToString();
                    string loggedUsername = UserUtils.GetLoggedUserName();
                    user user = UserUtils.GetUser(username);
                    Username = username;

                    switch (e.CommandName)
                    {
                        case "cmdDetails":
                            txtFullNameDetail.Text = user.full_name;
                            txtCellPhoneDetail.Text = user.cell_phone;
                            txtEmailDetail.Text = user.email;
                            txtRegistrationDate.Text = DateUtils.GetDateString_dd_MM_yyyy_hh_mm_ss(user.registration_date);
                            txtRegistrationUser.Text = user.registration_user;
                            txtMustChangePassword.Text = user.must_change_password.ToString();
                            txtLastPasswordChange.Text = DateUtils.GetDateString_dd_MM_yyyy_hh_mm_ss((DateTime)user.last_password_change);

                            PageUtils.DisplayModal(Page, "userDetails", "userDetails");
                            break;

                        case "cmdEdit":
                            if (user.username == AppConstants.General.SYS_ADMIN_USERNAME || user.username == loggedUsername
                                || user.status == Enumeration.DatabaseDataStatus.DELETED.ToString())
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                break;
                            }

                            txtFullName.Text = user.full_name;
                            txtCellPhone.Text = user.cell_phone;
                            txtEmail.Text = user.email;
                            ddlRole.SelectedValue = user.role;
                            PageUtils.HideUIControls(new object[] { pnlSucessUserUpdate, pnlErrorUserUpdate });
                            btnUpdateUser.Enabled = true;

                            PageUtils.DisplayModal(Page, "userUpdate", "userUpdate");
                            break;

                        case "cmdResetPassword":
                            if (user.username == AppConstants.General.SYS_ADMIN_USERNAME)
                            {
                                // When the parameterization key 'BYPASS' is set to true enables the sysadmin's password reset.
                                if (!ParameterizationUtils.GetBooleanParameterValue(AppConstants.ParameterizationKeys.BYPASS))
                                {
                                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                    break;
                                }
                            }

                            if (user.username == loggedUsername || user.status == Enumeration.DatabaseDataStatus.DELETED.ToString())
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                break;
                            }

                            txtUsername.Text = user.username;
                            PageUtils.HideUIControls(new object[] { pnlSucessResetPass, pnlErrorResetPass });
                            btnResetPassword.Enabled = true;

                            PageUtils.DisplayModal(Page, "resetUserPassword", "resetUserPassword");
                            break;

                        case "cmdUnlock":
                            if (user.username == AppConstants.General.SYS_ADMIN_USERNAME)
                            {
                                if (!ParameterizationUtils.GetBooleanParameterValue(AppConstants.ParameterizationKeys.BYPASS))
                                {
                                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                    break;
                                }
                            }

                            if (user.username == loggedUsername || user.status == Enumeration.DatabaseDataStatus.DELETED.ToString())
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                break;
                            }

                            user.locked = false;
                            user.current_login_attempts = 0;
                            UserUtils.UpdateUser(user);
                            ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                            RebindGrid();
                            break;

                        case "cmdDisable":
                            if (user.username == AppConstants.General.SYS_ADMIN_USERNAME
                             || user.username == loggedUsername
                             || user.status == Enumeration.DatabaseDataStatus.DELETED.ToString())
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                break;
                            }

                            user.disabled = true;
                            UserUtils.UpdateUser(user);
                            ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                            RebindGrid();
                            break;

                        case "cmdEnable":
                            if (user.username == AppConstants.General.SYS_ADMIN_USERNAME
                                   || user.username == loggedUsername
                                   || user.status == Enumeration.DatabaseDataStatus.DELETED.ToString())
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                break;
                            }

                            user.disabled = false;
                            UserUtils.UpdateUser(user);
                            ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                            RebindGrid();
                            break;

                        case "cmdDelete":
                            if (user.username == AppConstants.General.SYS_ADMIN_USERNAME
                                 || user.username == loggedUsername
                                 || user.status == Enumeration.DatabaseDataStatus.DELETED.ToString())
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                break;
                            }

                            lblConfirmMsg.Text = AppConstants.ConfirmMessage.CONF_DELETE_USER;
                            PageUtils.DisplayModal(Page, "confirmUserDelete", "confirmUserDelete");
                            break;

                        case "cmdRecover":
                            if (user.status != Enumeration.DatabaseDataStatus.DELETED.ToString())
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_OPERATION_NOT_ALLOWED, Enumeration.WarningType.Warning);
                                break;
                            }

                            user.status = Enumeration.DatabaseDataStatus.ACTIVE.ToString();
                            UserUtils.UpdateUser(user);
                            ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                            RebindGrid();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnConfirmDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            try
            {
                user user = UserUtils.GetUser(Username);
                user.status = Enumeration.DatabaseDataStatus.DELETED.ToString();
                UserUtils.UpdateUser(user);

                ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                RebindGrid();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdateUser control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    user user = UserUtils.GetUser(Username);

                    if (!StringUtils.IsFullNameValid(txtFullName.Text))
                    {
                        errorUserUpdateMsg.Text = AppConstants.ErrorMessage.ERROR_INVALID_USER_FULLNAME;
                        pnlSucessUserUpdate.Visible = false;
                        pnlErrorUserUpdate.Visible = true;
                        return;
                    }

                    user.full_name = txtFullName.Text;
                    user.cell_phone = txtCellPhone.Text;
                    if (txtEmail.Text != string.Empty)
                    {
                        user.email = txtEmail.Text;
                    }
                    user.role = ddlRole.SelectedValue;

                    UserUtils.UpdateUser(user);
                    RebindGrid();
                    btnUpdateUser.Enabled = false;

                    sucessUserUpdateMsg.Text = AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION;
                    pnlErrorUserUpdate.Visible = false;
                    pnlSucessUserUpdate.Visible = true;

                    RebindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnResetPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == string.Empty)
                {
                    errorResetPassMsg.Text = AppConstants.ErrorMessage.ERROR_REQUIRED_PASSWORD;
                    pnlErrorResetPass.Visible = true;
                    pnlSucessResetPass.Visible = false;

                    return;
                }

                user user = UserUtils.GetUser(Username);
                user.password = Security.HashPassword(txtUsername.Text, txtPassword.Text);
                user.must_change_password = true;

                UserUtils.UpdateUser(user);

                RebindGrid();
                btnResetPassword.Enabled = false;

                sucessResetPassMsg.Text = AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION;
                pnlErrorResetPass.Visible = false;
                pnlSucessResetPass.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkBtnRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkBtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RebindGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkBtnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkBtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(AppConstants.Page.USER_REGISTRATION);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Rebinds the rgUsers control.
        /// </summary>
        private void RebindGrid()
        {
            try
            {
                rgUsers.Rebind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}