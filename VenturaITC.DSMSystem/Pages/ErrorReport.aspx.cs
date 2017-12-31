using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;

namespace VenturaITC.DSMSystem.Pages
{
    public partial class ErrorReport : Page
    {
        public static string errorMsg { get; set; }

        /// <summary>
        /// Handles the Load event of the Page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtErrorMsg.Text = errorMsg;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnReport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);

            }
            catch (Exception ex)
            {
                //Nothing to do. Just log the error.
                GeneralUtils.LogError(ex.Message, ex);
            }
        }
        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(AppConstants.Page.DEFAULT);
            }
            catch (Exception ex)
            {
                //Nothing to do. Just log the error.
                GeneralUtils.LogError(ex.Message, ex);
            }
        }
    }
}