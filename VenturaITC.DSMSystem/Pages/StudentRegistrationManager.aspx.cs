using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using VenturaITC.DSMSystem.Reports;
using VenturaITC.DSMSystem.Util;
using VenturaITC.Files;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Handles the student registration managment process.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170701    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class StudentRegistrationManager : MainPage
    {
        public int StudentNumber
        {
            get
            {
                return (int)ViewState["studentNumber"];
            }
            set
            {
                ViewState["studentNumber"] = value;
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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.STUDENT_REGISTRATION_MANAGER);
            }
        }

        // <summary>
        /// Handles the RowDataBound of the gvStudents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    List<document_type> documentation = UWork<document_type>.GetAll();

                    DropDownList ddlDocumentation = (e.Row.FindControl("ddlDocumentation") as DropDownList);

                    ddlDocumentation.DataSource = documentation;
                    ddlDocumentation.DataValueField = "type";
                    ddlDocumentation.DataTextField = "description";
                    ddlDocumentation.DataBind();
                    ddlDocumentation.Items.Remove(ddlDocumentation.Items.FindByValue(Enumeration.DocumentType.PICTURE.ToString()));
                    ddlDocumentation.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                    ddlDocumentation.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        /// Handles the NeedDataSource event of the rgStudents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridNeedDataSourceEventArgs"/> instance containing the event data.</param>
        protected void rgStudents_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                rgStudents.DataSource = StudentUtils.GetStudentListWithAssociatedRegistration();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // <summary>
        /// Handles the ItemDataBound event of the rgStudents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridItemEventArgs"/> instance containing the event data.</param>
        protected void rgStudents_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    DropDownList ddlDocumentation = (DropDownList)item.FindControl("ddlDocumentation");

                    List<document_type> documentation = UWork<document_type>.GetAll();

                    ddlDocumentation.DataSource = documentation;
                    ddlDocumentation.DataValueField = "type";
                    ddlDocumentation.DataTextField = "description";
                    ddlDocumentation.DataBind();
                    ddlDocumentation.Items.Remove(ddlDocumentation.Items.FindByValue(Enumeration.DocumentType.PICTURE.ToString()));
                    ddlDocumentation.Items.Insert(0, new ListItem(AppConstants.General.DROPDOWNLIST_DEFAULT_TEXT, String.Empty));
                    ddlDocumentation.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the ItemCommand of the rgStudents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void rgStudents_ItemCommand(Object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    int studentNumber = Int32.Parse(((GridDataItem)e.Item).GetDataKeyValue("student_number").ToString());

                    switch (e.CommandName)
                    {
                        case "cmdDetails":
                            DataTable studentData = new DataTable();
                            studentData = StudentUtils.GetStudentWithAssociatedRegistration(studentNumber);

                            DataRow row = studentData.Rows[0];

                            lblNumber.Text = row["student_number"].ToString();
                            lblName.Text = row["full_name"].ToString();
                            lblBirthDate.Text = DateUtils.GetDateString_dd_MM_yyyy(DateUtils.StringToDate(row["birth_date"].ToString()));
                            lblPlaceOfBirth.Text = row["place_of_birth"].ToString();
                            lblProvinceOfBirth.Text = row["province_of_birth"].ToString();
                            lblFathersName.Text = row["fathers_name"].ToString();
                            lblMothersName.Text = row["mothers_name"].ToString();
                            lblMaritalStatus.Text = row["marital_status"].ToString();
                            lblGender.Text = row["gender"].ToString();
                            lblAddress.Text = row["address"].ToString();
                            lblIDNumber.Text = row["ID_number"].ToString();
                            lblIDIssuancePlace.Text = row["ID_issuance_place"].ToString();
                            lblIDIssuanceDate.Text = DateUtils.GetDateString_dd_MM_yyyy(DateUtils.StringToDate(row["ID_issuance_date"].ToString()));
                            lblIDExpiryDate.Text = DateUtils.GetDateString_dd_MM_yyyy(DateUtils.StringToDate(row["ID_expiry_date"].ToString()));
                            lblAcademicLevel.Text = row["academic_level"].ToString();
                            lblJobTitle.Text = row["job_title"].ToString();

                            lblCategory.Text = row["category"].ToString();
                            lblRegistrationDate.Text = DateUtils.GetDateString_dd_MM_yyyy(DateUtils.StringToDate(row["enrollment_date"].ToString()));
                            lblRegistrationUser.Text = row["enrollment_user"].ToString();
                            lblStudentType.Text = row["student_type"].ToString();

                            lblPhoneNumber.Text = row["phone_number"].ToString();
                            lblCellPhone1.Text = row["cell_phone1"].ToString();
                            lblCellPhone2.Text = row["cell_phone2"].ToString();
                            lblEmail.Text = row["email"].ToString();

                            byte[] studentPicture = (byte[])(row["picture"]);
                            imgPicture.ImageUrl = "data:image;png;base64," + Convert.ToBase64String(studentPicture);

                            PageUtils.DisplayModal(Page, "studentDetailsModal", "studentDetailsModal");
                            break;

                        case "cmdOpenDocument":
                            GridDataItem item = (GridDataItem)e.Item;
                            DropDownList ddlDocumentation = (DropDownList)item.FindControl("ddlDocumentation");

                            if (ddlDocumentation.SelectedValue == string.Empty)
                            {
                                ((SiteMaster)Master).ShowAlertNotification(AppConstants.WarningMessage.WARN_NOT_SELECTED_DOCUMENT_TYPE, Enumeration.WarningType.Warning);
                                return;
                            }

                            student_documentation document = StudentUtils.GetStudentDocument(studentNumber, ddlDocumentation.SelectedValue);

                            byte[] doc = document.document_content;

                            string path = GeneralUtils.GetUserTempDir();
                            string fileName = GeneralUtils.GetDocumentFileName(ddlDocumentation.SelectedValue);
                            string filePath = path + fileName;

                            File.WriteAllBytes(filePath, doc);

                            Session[AppConstants.SessionVariables.FILE_PATH] = filePath;

                            PageUtils.OpenNewBrowserTab(Page, AppConstants.Page.PDF_VIEWER);
                            break;


                        case "cmdPrintFile":
                            DataTable studentFile = new DataTable();
                            studentFile = StudentUtils.GetStudentWithAssociatedRegistration(studentNumber);
                            ReportDocument rpt = new RptStudentFile();

                            rpt.SetDataSource(studentFile);

                            string _path = GeneralUtils.GetUserTempDir();
                            string _fileName = AppConstants.FileNames.PDF_STUDENT_FILE;
                            string _filePath = _path + _fileName;

                            FileManager.GeneratePDFReport(rpt, _path, _fileName);

                            Session[AppConstants.SessionVariables.FILE_PATH] = _filePath;

                            PageUtils.OpenNewBrowserTab(Page, AppConstants.Page.PDF_VIEWER);
                            break;

                        case "cmdEdit":
                            Response.Redirect(AppConstants.Page.STUDENT_DATA_UPDATE + "?" + AppConstants.QueryString.STUDENT_NUMBER + "=" + studentNumber);
                            break;


                        case "cmdDelete":
                            lblConfirmMsg.Text = AppConstants.ConfirmMessage.CONF_DELETE_STUDENT;
                            PageUtils.DisplayModal(Page, "confirmStudentDelete", "confirmStudentDelete");
                            StudentNumber = studentNumber;
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
                student student = StudentUtils.GetStudent(StudentNumber);
                student.status = Enumeration.DatabaseDataStatus.DELETED.ToString();
                StudentUtils.UpdateStudent(student);

                ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);

                rgStudents.DataSource = StudentUtils.GetStudentListWithAssociatedRegistration();
                rgStudents.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}