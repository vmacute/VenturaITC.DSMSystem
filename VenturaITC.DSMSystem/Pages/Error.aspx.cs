using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VenturaITC.DSMSystem.MODEL.Class;

namespace VenturaITC.DSMSystem.Pages
{
    public partial class Error : System.Web.UI.Page
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
                lblCopyright.Text = "© " + DateTime.Now.Year + " - " + Properties.Settings.Default.SchoolName;
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
                ErrorReport.errorMsg = txtErrorMsg.Text;
               // Response.Redirect(AppConstants.Page.ERROR_REPORT);
            }
            catch (Exception)
            {
                //Nothing to do. Just log the error.
            }
        }
    }
}