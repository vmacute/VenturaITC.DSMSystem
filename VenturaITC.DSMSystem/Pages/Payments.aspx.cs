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
using VenturaITC.Files;

namespace VenturaITC.DSMSystem.Pages
{

    /// <summary>
    /// Page for payments
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170724    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class Payments : MainPage
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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.PAYMENTS);
                BindDdlFilter();
            }
        }


        /// <summary>
        /// Binds the ddlFilter DropDownList control.
        /// </summary>
        private void BindDdlFilter()
        {
            try
            {
                List<payment_status> paymentStatus = UWork<payment_status>.GetAll();

                ddlFilter.Items.Clear();

                ddlFilter.DataSource = paymentStatus;
                ddlFilter.DataValueField = "name";
                ddlFilter.DataTextField = "description";
                ddlFilter.DataBind();

                ddlFilter.Items.Insert(0, new ListItem(AppConstants.General.ALL_TEXT, Enumeration.PaymentStatus.ALL.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the OnSelectedIndexChanged of the ddlFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlFilter_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rgPayments.DataSource = StudentUtils.GetStudentListWithAssociatedRegistration(ddlFilter.SelectedValue);
                rgPayments.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        /// Handles the NeedDataSource of the rgPayments control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
        protected void rgPayments_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgPayments.DataSource = StudentUtils.GetStudentListWithAssociatedRegistration();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the ItemCommand of the rgPayments control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridCommandEventArgs"/> instance containing the event data.</param>
        protected void rgPayments_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    int studentNumber = Int32.Parse(((GridDataItem)e.Item).GetDataKeyValue("student_number").ToString());

                    switch (e.CommandName)
                    {
                        case "cmdShowPayments":
                            Response.Redirect(AppConstants.Page.STUDENT_PAYMENTS + "?" + AppConstants.QueryString.STUDENT_NUMBER + "=" + studentNumber);
                            break;

                        case "cmdShowPaymentsHist":
                            Response.Redirect(AppConstants.Page.STUDENT_PAYMENTS_HISTORY + "?" + AppConstants.QueryString.STUDENT_NUMBER + "=" + studentNumber);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// Handles the Click event of the lnkBtnExportExcel control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //protected void lnkBtnExportExcel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FileManager.DownloadExcel(StudentUtils.GetStudentListWithAssociatedRegistration_Excel(ddlFilter.SelectedValue), AppConstants.FileNames.EXCEL_STUDENT_LIST);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}