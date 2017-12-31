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
using VenturaITC.VenturaITC.DSMSystem.BLL.Unit;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Page for student data update.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170719    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class StudentDataUpdate : MainPage
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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.STUDENT_DATA_UPDATE);

                string studentNumberStr = Request.QueryString[AppConstants.QueryString.STUDENT_NUMBER];
                if (studentNumberStr == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_NUMBER);
                }

                BindDdlStudentType();
                BindDdlGender();
                BindDdlMaritalStatus();
                BindDdlProvinceOfBirth();
                BindDdlIDIssuancePlace();
                BindDdlAcademicLevel();

                int studentNumber = Convert.ToInt32(studentNumberStr);

                FillFields(studentNumber);
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
                ddlStudentType.SelectedIndex = 0;
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
        /// Fills the form fields.
        /// </summary>
        /// <param name="studentNumber">The student number</param>
        private void FillFields(int studentNumber)
        {
            try
            {
                student student = StudentUtils.GetStudent(studentNumber);

                txtStudentNumber.Text = student.number.ToString();
                ddlStudentType.SelectedValue = student.type;
                txtName.Text = student.full_name;
                txtBirthDate.Text = DateUtils.GetDateString_yyyy_MM_dd(student.birth_date);
                ddlGender.SelectedValue = student.gender;
                ddlMaritalStatus.SelectedValue = student.marital_status;
                txtPlaceOfBirth.Text = student.place_of_birth;
                ddlProvinceOfBirth.SelectedValue = student.province_of_birth;
                txtFathersName.Text = student.fathers_name;
                txtMothersName.Text = student.mothers_name;
                txtAddress.Text = student.address;
                txtIDNumber.Text = student.ID_number;
                ddlIDIssuancePlace.SelectedValue = student.ID_issuance_place;
                txtIDIssuanceDate.Text = DateUtils.GetDateString_yyyy_MM_dd(student.ID_issuance_date);
                txtIDExpiryDate.Text = DateUtils.GetDateString_yyyy_MM_dd(student.ID_expiry_date);
                ddlAcademicLevel.SelectedValue = student.academic_level;
                txtPhoneNumber.Text = student.phone_number;
                txtCellPhone1.Text = student.cell_phone1;
                txtCellPhone2.Text = student.cell_phone2;
                txtEmail.Text = student.email;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validates the fields.
        /// </summary>
        /// <returns>true if the fields are correctly filled; false otherwise.</returns>
        private bool ValidateFields()
        {
            try
            {
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

                //Validates the documents size.
                string docMaxSize = " (" + MathematicsUtils.ToMegabytes(ParameterizationUtils.GetDocumentMaxAllowedSize()) + " MB)";

                if (fUpldPicture.HasFile)
                {
                    if (!Validator.IsDocumentSizeAllowed(fUpldPicture.PostedFile.ContentLength))
                    {
                        ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_PICTURE + docMaxSize, Enumeration.WarningType.Danger);
                        return false;
                    }
                }

                if (fUpldIDCopy.HasFile)
                {
                    if (!Validator.IsDocumentSizeAllowed(fUpldIDCopy.PostedFile.ContentLength))
                    {
                        ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_IDCOPY + docMaxSize, Enumeration.WarningType.Danger);
                        return false;
                    }
                }

                if (fUpldCriminalRecord.HasFile)
                {
                    if (!Validator.IsDocumentSizeAllowed(fUpldCriminalRecord.PostedFile.ContentLength))
                    {
                        ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_CRIMINAL_RECORD + docMaxSize, Enumeration.WarningType.Danger);
                        return false;
                    }
                }

                if (fUpldMedicalCertificate.HasFile)
                {
                    if (!Validator.IsDocumentSizeAllowed(fUpldMedicalCertificate.PostedFile.ContentLength))
                    {
                        ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_MEDICAL_CERTIFICATE + docMaxSize, Enumeration.WarningType.Danger);
                        return false;
                    }
                }

                if (fUpldMilitarServDeclaration.HasFile)
                {
                    if (!Validator.IsDocumentSizeAllowed(fUpldMilitarServDeclaration.PostedFile.ContentLength))
                    {
                        ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_DOC_EXCEEDS_SIZE_MILITAR_SERV_DECL + docMaxSize, Enumeration.WarningType.Danger);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    int stNumber = StudentUtils.GetStudentNumber(txtStudentNumber.Text);
                    student student = StudentUtils.GetStudent(stNumber);

                    student.full_name = txtName.Text.Trim();
                    student.birth_date = DateTime.Parse(txtBirthDate.Text);
                    student.gender = ddlGender.SelectedValue;
                    student.marital_status = ddlMaritalStatus.SelectedValue;
                    student.place_of_birth = txtPlaceOfBirth.Text;
                    student.province_of_birth = ddlProvinceOfBirth.SelectedValue;
                    student.fathers_name = txtFathersName.Text;
                    student.mothers_name = txtMothersName.Text;
                    student.address = txtAddress.Text;
                    student.ID_number = txtIDNumber.Text;
                    student.ID_issuance_place = ddlIDIssuancePlace.SelectedValue;
                    student.ID_issuance_date = DateTime.Parse(txtIDIssuanceDate.Text);
                    student.ID_expiry_date = DateTime.Parse(txtIDExpiryDate.Text);
                    student.academic_level = ddlAcademicLevel.SelectedValue;
                    student.job_title = txtJobTitle.Text;
                    student.phone_number = txtPhoneNumber.Text;
                    student.cell_phone1 = txtCellPhone1.Text;
                    student.cell_phone2 = txtCellPhone2.Text;
                    student.email = txtEmail.Text;

                    using (GUWork work = new GUWork())
                    {
                        //student data.
                        work.SetEntityType<student>();
                        work.Entity.number = student.number;
                        work.Entity.type = student.type;
                        work.Entity.type_description = student.type_description;
                        work.Entity.full_name = student.full_name;
                        work.Entity.first_name = student.first_name;
                        work.Entity.last_name = student.last_name;
                        work.Entity.birth_date = student.birth_date;
                        work.Entity.marital_status = student.marital_status;
                        work.Entity.marital_status_description = student.marital_status_description;
                        work.Entity.gender = student.gender;
                        work.Entity.gender_description = student.gender_description;
                        work.Entity.place_of_birth = student.place_of_birth;
                        work.Entity.province_of_birth = student.province_of_birth;
                        work.Entity.fathers_name = student.fathers_name;
                        work.Entity.mothers_name = student.mothers_name;
                        work.Entity.address = student.address;
                        work.Entity.ID_number = student.ID_number;
                        work.Entity.ID_issuance_place = student.ID_issuance_place;
                        work.Entity.ID_issuance_date = student.ID_issuance_date;
                        work.Entity.ID_expiry_date = student.ID_expiry_date;
                        work.Entity.academic_level = student.academic_level;
                        work.Entity.job_title = student.job_title;
                        work.Entity.phone_number = student.phone_number;
                        work.Entity.cell_phone1 = student.cell_phone1;
                        work.Entity.cell_phone2 = student.cell_phone2;
                        work.Entity.email = student.email;
                        work.Entity.status = student.status;

                        work.Update(false);

                        if (fUpldPicture.HasFile)
                        {
                            student_documentation studentDocumentation = StudentUtils.GetStudentDocument(stNumber, Enumeration.DocumentType.PICTURE.ToString());

                            work.SetEntityType<student_documentation>();
                            work.Entity.id = studentDocumentation.id;
                            work.Entity.student_number = studentDocumentation.student_number;
                            work.Entity.document_type = studentDocumentation.document_type;
                            work.Entity.document_content = fUpldPicture.FileBytes;
                            work.Update(false);
                        }

                        if (fUpldIDCopy.HasFile)
                        {
                            student_documentation studentDocumentation = StudentUtils.GetStudentDocument(stNumber, Enumeration.DocumentType.ID_COPY.ToString());

                            work.SetEntityType<student_documentation>();
                            work.Entity.id = studentDocumentation.id;
                            work.Entity.student_number = studentDocumentation.student_number;
                            work.Entity.document_type = studentDocumentation.document_type;
                            work.Entity.document_content = fUpldIDCopy.FileBytes;
                            work.Update(false);
                        }


                        if (fUpldCriminalRecord.HasFile)
                        {
                            student_documentation studentDocumentation = StudentUtils.GetStudentDocument(stNumber, Enumeration.DocumentType.CRIMINAL_RECORD.ToString());

                            work.SetEntityType<student_documentation>();
                            work.Entity.id = studentDocumentation.id;
                            work.Entity.student_number = studentDocumentation.student_number;
                            work.Entity.document_type = studentDocumentation.document_type;
                            work.Entity.document_content = fUpldCriminalRecord.FileBytes;
                            work.Update(false);
                        }

                        if (fUpldMedicalCertificate.HasFile)
                        {
                            student_documentation studentDocumentation = StudentUtils.GetStudentDocument(stNumber, Enumeration.DocumentType.MEDICAL_CERTIFICATE.ToString());

                            work.SetEntityType<student_documentation>();
                            work.Entity.id = studentDocumentation.id;
                            work.Entity.student_number = studentDocumentation.student_number;
                            work.Entity.document_type = studentDocumentation.document_type;
                            work.Entity.document_content = fUpldMedicalCertificate.FileBytes;
                            work.Update(false);
                        }

                        if (fUpldMilitarServDeclaration.HasFile)
                        {
                            student_documentation studentDocumentation = StudentUtils.GetStudentDocument(stNumber, Enumeration.DocumentType.MILITAR_SERVICE_DECLARATION.ToString());

                            work.SetEntityType<student_documentation>();
                            work.Entity.id = studentDocumentation.id;
                            work.Entity.student_number = studentDocumentation.student_number;
                            work.Entity.document_type = studentDocumentation.document_type;
                            work.Entity.document_content = fUpldMedicalCertificate.FileBytes;
                            work.Entity.document_content = fUpldMilitarServDeclaration.FileBytes;
                            work.Update(false);
                        }

                        //Submit the transaction
                        work.Update();
                    }

                    PageUtils.DisableUIControls(new object[] { btnUpdate });
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                }
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
                Response.Redirect(AppConstants.Page.STUDENT_REGISTRATION_MANAGER);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}