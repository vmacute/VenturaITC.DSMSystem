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
using VenturaITC.DSMSystem.Util;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Handles the student payments.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170723    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class StudentPayments : MainPage
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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.STUDENT_PAYMENTS);

                string studentNumberStr = Request.QueryString[AppConstants.QueryString.STUDENT_NUMBER];
                if (studentNumberStr == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_NUMBER);
                }

                int studentNumber = Convert.ToInt32(studentNumberStr);

                FillFields(studentNumber);
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
                category category = PaymentUtils.GetCategory(registration.category);
                student_payment studentPayment = PaymentUtils.GetStudentLastPayment(studentNumber);

                txtStudentNumber.Text = student.number.ToString();
                txtName.Text = student.full_name;
                txtCategory.Text = category.description;
                txtRegistrationDate.Text = DateUtils.GetDateString_yyyy_MM_dd(registration.enrollment_date);

                if (PaymentUtils.IsStudentPaymentFinished(studentNumber))
                {
                    pnlInfo.Visible = true;
                    return;
                }

                int currInstallment = (int)(studentPayment.installment_number + 1);

                txtCost.Text = category.cost.ToString();
                txtPaidAmount.Text = studentPayment.total_paid_amount.ToString();
                txtRemainingAmount.Text = studentPayment.remaining_amount.ToString();
                txtInstallment.Text = currInstallment.ToString();
                txtInstallmentAmount.Text = PaymentUtils.GetInstallmentAmount(currInstallment, category.cost).ToString();
                txtMinAmount.Text = PaymentUtils.GetPaymentMinAmount(studentNumber, currInstallment).ToString();
                txtAmountToPay.Text = txtMinAmount.Text;

                pnlPayments.Visible = true;
                btnSubmit.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (PaymentUtils.ExistsReceiptNumber(Convert.ToInt32(txtReceiptNumber.Text)))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_ALREADY_EXISTS_RECEIPT_NUMBER, Enumeration.WarningType.Danger);
                    return;
                }

                int studentNumber = StudentUtils.GetStudentNumber(txtStudentNumber.Text);
                MODEL.Entity.student_enrollment registration = StudentUtils.GetStudentRegistration(studentNumber);
                student_payment studentPayment = PaymentUtils.GetStudentLastPayment(studentNumber);
                category category = UWork<category>.FindByKey(registration.category);

                using (UWork<student_payment> work = new UWork<student_payment>())
                {
                    work.Entity.receipt_number = Convert.ToInt32(txtReceiptNumber.Text);
                    work.Entity.student_number = studentNumber;
                    work.Entity.installment_number = Convert.ToInt32(txtInstallment.Text);
                    work.Entity.amount = Convert.ToDecimal(txtAmountToPay.Text);
                    work.Entity.total_paid_amount = studentPayment.total_paid_amount + Convert.ToDecimal(txtAmountToPay.Text);
                    work.Entity.remaining_amount = studentPayment.remaining_amount - (Convert.ToDecimal(txtAmountToPay.Text));
                    work.Entity.username = UserUtils.GetLoggedUserName();
                    work.Entity.date = DateTime.Now;
                    work.Save();
                }

                PageUtils.DisableUIControls(new object[] { btnSubmit });
                ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Handles the Click event of the btnBack_Click control.
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