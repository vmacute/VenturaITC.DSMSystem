using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;
using VenturaITC.DSMSystem.Reports;
using VenturaITC.DSMSystem.Util;
using VenturaITC.Files;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Page for payments history.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170725    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class StudentPaymentsHistory : MainPage
    {
        public int StudentNumber
        {
            get { return (int)ViewState["studentNumber"]; }
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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.STUDENT_PAYMENTS_HISTORY);

                string studentNumberStr = Request.QueryString[AppConstants.QueryString.STUDENT_NUMBER];
                if (studentNumberStr == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_NUMBER);
                }

                int studentNumber = Convert.ToInt32(studentNumberStr);

                ViewState["studentNumber"] = studentNumber;

                FillFields(studentNumber);

                BindPaymentsRadGrid(studentNumber);
            }
        }

        /// <summary>
        /// Fills the form fields.
        /// </summary>
        /// <param name="studentNumber">The student number</param>
        private void FillFields(int studentNumber)
        {
            try
            {               
                student student = StudentUtils.GetStudent(studentNumber);
                MODEL.Entity.student_enrollment registration = StudentUtils.GetStudentRegistration(studentNumber);               
                category category = UWork<category>.FindByKey(registration.category);

                txtStudentNumber.Text = student.number.ToString();
                txtName.Text = student.full_name;
                txtCategory.Text = category.description;
                txtRegistrationDate.Text = DateUtils.GetDateString_yyyy_MM_dd(registration.enrollment_date);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Binds the student payments history RadGrid.
        /// </summary>
        /// <param name="studentNumber">The student number</param>
        private void BindPaymentsRadGrid(int studentNumber)
        {
            try
            {
                List<student_payment> studentPayments = PaymentUtils.GetStudentPayments(StudentNumber);

               rgPayments.DataSource = studentPayments;
                rgPayments.DataBind();
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
            int studentNumber = StudentNumber;

            switch (e.CommandName)
            {
                case "cmdPrintStatement":
                    List<student_payment> payments = PaymentUtils.GetStudentPayments(StudentNumber);
                    DataTable studentData = new DataTable();
                    DataTable statementData = new DataTable();

                    studentData = StudentUtils.GetStudentWithAssociatedRegistration(studentNumber);
                    statementData = GeneralUtils.ToDataTable(payments);

                    ReportDocument rpt = new RptPaymentStatement();

                    rpt.SetDataSource(studentData);
                    rpt.Subreports[AppConstants.Reports.SUB_RPT_PAYMENT_STATEMENT].SetDataSource(statementData);

                    string path = GeneralUtils.GetUserTempDir();
                    string fileName = AppConstants.FileNames.PDF_PAYMENTS_STATEMENT;
                    string filePath = path + fileName;

                    FileManager.GeneratePDFReport(rpt, path, fileName);

                    Session[AppConstants.SessionVariables.FILE_PATH] = filePath;

                    PageUtils.OpenNewBrowserTab(Page, AppConstants.Page.PDF_VIEWER);
                    break;
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
                Response.Redirect(AppConstants.Page.PAYMENTS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
