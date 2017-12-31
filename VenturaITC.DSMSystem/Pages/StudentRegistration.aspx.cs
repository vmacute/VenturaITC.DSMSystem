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
using VenturaITC.VenturaITC.DSMSystem.BLL.Unit;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Handles the student data registration process.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170630    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class StudentRegistration : MainPage
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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.STUDENT_REGISTRATION);

                BindDdlStudentType();
                BindDdlGender();
                BindDdlMaritalStatus();
                BindDdlProvinceOfBirth();
                BindDdlIDIssuancePlace();
                BindDdlAcademicLevel();
                BindDdlCategory();
                BindDdlPaymentType();
            }
        }

        /// <summary>
        /// Binds the ddlStudentType DropDownList control.
        /// </summary>
        private void BindDdlStudentType()
        {
            try
            {
                List<student_type> pList = UWork<student_type>.GetAll();

                ddlStudentType.Items.Clear();

                ddlStudentType.DataSource = pList;
                ddlStudentType.DataValueField = "name";
                ddlStudentType.DataTextField = "description";
                ddlStudentType.DataBind();

                ddlStudentType.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlStudentType.SelectedValue = Enumeration.StudentType.INTERNAL.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlGender DropDownList control.
        /// </summary>
        private void BindDdlGender()
        {
            try
            {
                List<gender> categoryList = UWork<gender>.GetAll();

                ddlGender.Items.Clear();

                ddlGender.DataSource = categoryList;
                ddlGender.DataValueField = "name";
                ddlGender.DataTextField = "description";
                ddlGender.DataBind();

                ddlGender.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlGender.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlMaritalStatus DropDownList control.
        /// </summary>
        private void BindDdlMaritalStatus()
        {
            try
            {
                List<marital_status> categoryList = UWork<marital_status>.GetAll();

                ddlMaritalStatus.Items.Clear();

                ddlMaritalStatus.DataSource = categoryList;
                ddlMaritalStatus.DataValueField = "name";
                ddlMaritalStatus.DataTextField = "description";
                ddlMaritalStatus.DataBind();

                ddlMaritalStatus.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlMaritalStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlProvinceOfBirth DropDownList control.
        /// </summary>
        private void BindDdlProvinceOfBirth()
        {
            try
            {
                List<province> pList = UWork<province>.GetAll();

                ddlProvinceOfBirth.Items.Clear();

                ddlProvinceOfBirth.DataSource = pList;
                ddlProvinceOfBirth.DataValueField = "name";
                ddlProvinceOfBirth.DataBind();

                ddlProvinceOfBirth.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlProvinceOfBirth.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlIdIssuancePlace DropDownList control.
        /// </summary>
        private void BindDdlIDIssuancePlace()
        {
            try
            {
                List<id_issuance_place> pList = UWork<id_issuance_place>.GetAll();

                ddlIDIssuancePlace.Items.Clear();

                ddlIDIssuancePlace.DataSource = pList;
                ddlIDIssuancePlace.DataValueField = "name";
                ddlIDIssuancePlace.DataBind();

                ddlIDIssuancePlace.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlIDIssuancePlace.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlAcademicLevel DropDownList control.
        /// </summary>
        private void BindDdlAcademicLevel()
        {
            try
            {
                List<academic_level> pList = UWork<academic_level>.GetAll();

                ddlAcademicLevel.Items.Clear();

                ddlAcademicLevel.DataSource = pList;
                ddlAcademicLevel.DataValueField = "name";
                ddlAcademicLevel.DataBind();

                ddlAcademicLevel.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlAcademicLevel.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlCategory DropDownList control.
        /// </summary>
        private void BindDdlCategory()
        {
            try
            {
                List<category> categoryList = UWork<category>.GetAll();

                ddlCategory.Items.Clear();

                ddlCategory.DataSource = categoryList;
                ddlCategory.DataValueField = "name";
                ddlCategory.DataTextField = "description";
                ddlCategory.DataBind();

                ddlCategory.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Binds the ddlPaymentType DropDownList control.
        /// </summary>
        private void BindDdlPaymentType()
        {
            try
            {
                List<payment_type> paymentTypes = UWork<payment_type>.GetAll();

                ddlPaymentType.Items.Clear();

                ddlPaymentType.DataSource = paymentTypes;
                ddlPaymentType.DataValueField = "name";
                ddlPaymentType.DataTextField = "description";
                ddlPaymentType.DataBind();

                ddlPaymentType.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                ddlPaymentType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the OnSelectedIndexChanged of the ddlCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal amount = PaymentUtils.GetCategoryCost(ddlCategory.SelectedValue);

                PageUtils.ClearUIControls(new object[] { ddlPaymentType, txtTotalAmount, txtMinimumAmount, txtAmountToPay });
                ddlPaymentType.Enabled = false;

                txtTotalAmount.Text = amount.ToString();

                if (ddlCategory.SelectedValue == string.Empty)
                {
                    ddlPaymentType.Enabled = false;
                }
                else
                {
                    ddlPaymentType.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the OnSelectedIndexChanged of the ddlPayments control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ddlPaymentType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            decimal amount = -1;

            try
            {
                if (ddlPaymentType.SelectedValue == Enumeration.PaymentType.TOTAL.ToString())
                {
                    amount = Convert.ToDecimal(txtTotalAmount.Text);
                }

                if (ddlPaymentType.SelectedValue == Enumeration.PaymentType.PARTIAL.ToString())
                {
                    amount = PaymentUtils.GetInstallmentAmount(1, Convert.ToDecimal(txtTotalAmount.Text));
                }

                txtMinimumAmount.Text = amount != -1 ? amount.ToString() : string.Empty;
                txtAmountToPay.Text = amount != -1 ? amount.ToString() : string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event  of the btnRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dynamic StudentEntity;

                    using (GUWork work = new GUWork())
                    {
                        //student data.
                        work.SetEntityType<student>();
                        work.Entity.type = ddlStudentType.SelectedValue;
                        work.Entity.type_description = ddlStudentType.SelectedItem.Text;
                        work.Entity.number = int.Parse(txtStudentNumber.Text.Trim());
                        work.Entity.full_name = txtName.Text.Trim();
                        work.Entity.first_name = StudentUtils.GetFirstName(txtName.Text.Trim());
                        work.Entity.last_name = StudentUtils.GetLastName(txtName.Text.Trim());
                        work.Entity.birth_date = DateTime.Parse(txtBirthDate.Text);
                        work.Entity.gender = ddlGender.SelectedValue;
                        work.Entity.gender_description = ddlGender.SelectedItem.Text;
                        work.Entity.marital_status = ddlMaritalStatus.SelectedValue;
                        work.Entity.marital_status_description = ddlMaritalStatus.SelectedItem.Text;
                        work.Entity.place_of_birth = txtPlaceOfBirth.Text;
                        work.Entity.province_of_birth = ddlProvinceOfBirth.SelectedValue;
                        work.Entity.fathers_name = txtFathersName.Text;
                        work.Entity.mothers_name = txtMothersName.Text;
                        work.Entity.address = txtAddress.Text;
                        work.Entity.ID_number = txtIDNumber.Text;
                        work.Entity.ID_issuance_place = ddlIDIssuancePlace.SelectedValue;
                        work.Entity.ID_issuance_date = DateTime.Parse(txtIDIssuanceDate.Text);
                        work.Entity.ID_expiry_date = DateTime.Parse(txtIDExpiryDate.Text);
                        work.Entity.academic_level = ddlAcademicLevel.SelectedValue;
                        work.Entity.job_title = txtJobTitle.Text;
                        work.Entity.phone_number = txtPhoneNumber.Text;
                        work.Entity.cell_phone1 = txtCellPhone1.Text;
                        work.Entity.cell_phone2 = txtCellPhone2.Text;
                        work.Entity.email = txtEmail.Text;
                        work.Entity.status = Enumeration.DatabaseDataStatus.ACTIVE.ToString();
                        work.Save(submit: false);

                        //Hold the student Entity.
                        StudentEntity = work.Entity;

                        //student registration data.
                        work.SetEntityType<student_enrollment>();
                        work.Entity.student = StudentEntity;
                        work.Entity.category = ddlCategory.SelectedValue;
                        work.Entity.enrollment_date = DateTime.Now;
                        work.Entity.enrollment_user = UserUtils.GetLoggedUserName();
                        work.Save(submit: false);

                        //Payment.
                        decimal amount = Convert.ToDecimal(txtAmountToPay.Text);
                        decimal cost = PaymentUtils.GetCategoryCost(ddlCategory.SelectedValue);

                        work.SetEntityType<student_payment>();
                        work.Entity.receipt_number = Convert.ToInt32(txtReceiptNumber.Text);
                        work.Entity.student = StudentEntity;

                        if (ddlPaymentType.SelectedValue != Enumeration.PaymentType.TOTAL.ToString())
                        {
                            work.Entity.installment_number = 1;
                        }

                        work.Entity.amount = amount;
                        work.Entity.total_paid_amount = amount;
                        work.Entity.remaining_amount = cost - amount;
                        work.Entity.username = UserUtils.GetLoggedUserName();
                        work.Entity.date = DateTime.Now;
                        work.Save(submit: false);

                        //student documentation.
                        work.SetEntityType<student_documentation>();
                        work.Entity.student = StudentEntity;
                        work.Entity.document_type = Enumeration.DocumentType.PICTURE.ToString();
                        work.Entity.document_content = fUpldPicture.FileBytes;
                        work.Save(submit: false);

                        work.SetEntityType<student_documentation>();
                        work.Entity.student = StudentEntity;
                        work.Entity.document_type = Enumeration.DocumentType.ID_COPY.ToString();
                        work.Entity.document_content = fUpldIDCopy.FileBytes;
                        work.Save(submit: false);

                        work.SetEntityType<student_documentation>();
                        work.Entity.student = StudentEntity;
                        work.Entity.document_type = Enumeration.DocumentType.CRIMINAL_RECORD.ToString();
                        work.Entity.document_content = fUpldCriminalRecord.FileBytes;
                        work.Save(submit: false);

                        work.SetEntityType<student_documentation>();
                        work.Entity.student = StudentEntity;
                        work.Entity.document_type = Enumeration.DocumentType.MEDICAL_CERTIFICATE.ToString();
                        work.Entity.document_content = fUpldMedicalCertificate.FileBytes;
                        work.Save(submit: false);

                        work.SetEntityType<student_documentation>();
                        work.Entity.student = StudentEntity;
                        work.Entity.document_type = Enumeration.DocumentType.MILITAR_SERVICE_DECLARATION.ToString();
                        work.Entity.document_content = fUpldMilitarServDeclaration.FileBytes;
                        work.Save(submit: false);

                        //Submit the data into database.
                        work.Save();

                        //txtStudentNumber.Text = StudentEntity.number.ToString();
                    }

                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);

                    PageUtils.DisableUIControls(new object[] { btnRegister });
                    PageUtils.ShowUIControls(new object[] { btnPrintFile });
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
        /// Handles the Click event of the btnPrintFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnPrintFile_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            try
            {
                data = StudentUtils.GetStudentWithAssociatedRegistration(StudentUtils.GetStudentNumber(txtStudentNumber.Text));
                ReportDocument rpt = new RptStudentFile();

                rpt.SetDataSource(data);

                string path = GeneralUtils.GetUserTempDir();
                string fileName = AppConstants.FileNames.PDF_STUDENT_FILE;
                string filePath = path + fileName;

                FileManager.GeneratePDFReport(rpt, path, fileName);

                Session[AppConstants.SessionVariables.FILE_PATH] = filePath;

                PageUtils.OpenNewBrowserTab(Page, AppConstants.Page.PDF_VIEWER);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validates the fields.
        /// </summary>
        /// <returns></returns>
        private bool ValidateFields()
        {
            try
            {
                //Validates the receipt number.
                if (StudentUtils.ExistsStudentNumber(int.Parse(txtStudentNumber.Text)))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_ALREADY_EXISTS_STUDENT_NUMBER, Enumeration.WarningType.Danger);
                    return false;
                }

                //Validates the names.
                if (!StringUtils.IsFullNameValid(txtName.Text))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_INVALID_STUDENT_NAME, Enumeration.WarningType.Danger);
                    return false;
                }

                if (!StringUtils.IsFullNameValid(txtFathersName.Text))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_INVALID_FATHERS_NAME, Enumeration.WarningType.Danger);
                    return false;
                }

                if (!StringUtils.IsFullNameValid(txtMothersName.Text))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_INVALID_MOTHERST_NAME, Enumeration.WarningType.Danger);
                    return false;
                }

                //Validates the date of birth.
                if (DateUtils.IsDate1AfterDate2(DateTime.Parse(txtBirthDate.Text), DateTime.Now))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DATE_OF_BIRTH_IN_FUTURE, Enumeration.WarningType.Danger);
                    return false;
                }

                //Validates the receipt number.
                if (PaymentUtils.ExistsReceiptNumber(Convert.ToInt32(txtReceiptNumber.Text)))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_ALREADY_EXISTS_RECEIPT_NUMBER, Enumeration.WarningType.Danger);
                    return false;
                }

                //Validates the documents size.
                string docMaxSize = " (" + MathematicsUtils.ToMegabytes(ParameterizationUtils.GetDocumentMaxAllowedSize()) + " MB)";
                if (!Validator.IsDocumentSizeAllowed(fUpldPicture.PostedFile.ContentLength))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_PICTURE + docMaxSize, Enumeration.WarningType.Danger);
                    return false;
                }

                if (!Validator.IsDocumentSizeAllowed(fUpldIDCopy.PostedFile.ContentLength))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_IDCOPY + docMaxSize, Enumeration.WarningType.Danger);
                    return false;
                }

                if (!Validator.IsDocumentSizeAllowed(fUpldCriminalRecord.PostedFile.ContentLength))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_CRIMINAL_RECORD + docMaxSize, Enumeration.WarningType.Danger);
                    return false;
                }

                if (!Validator.IsDocumentSizeAllowed(fUpldMedicalCertificate.PostedFile.ContentLength))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_MEDICAL_CERTIFICATE + docMaxSize, Enumeration.WarningType.Danger);
                    return false;
                }

                if (!Validator.IsDocumentSizeAllowed(fUpldMilitarServDeclaration.PostedFile.ContentLength))
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_MILITAR_SERV_DECL + docMaxSize, Enumeration.WarningType.Danger);
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}