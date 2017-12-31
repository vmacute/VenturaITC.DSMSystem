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
    /// Handles the parameterization page's code.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170819    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class Parameterization : MainPage
    {
        /// <summary>
        /// Gets or sets the selected installments option.
        /// </summary>
        public int Installments
        {
            get
            {
                return (int)ViewState["installments"];
            }
            set
            {
                ViewState["installments"] = value;
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
                PermissionManager.CheckUserPermition(UserUtils.GetLoggedUserRole(), AppConstants.Page.PARAMETERIZATION);
                FillFields();
            }
        }

        /// <summary>
        /// Fills the form fields.
        /// </summary>
        private void FillFields()
        {
            try
            {
                txtLightVehiclePrice.Text = PaymentUtils.GetCategoryCost(Enumeration.Category.LIGHT_VEHICLE.ToString()).ToString();
                txtHeavyVehiclePrice.Text = PaymentUtils.GetCategoryCost(Enumeration.Category.HEAVY_VEHICLE.ToString()).ToString();
                txtMotorcyclePrice.Text = PaymentUtils.GetCategoryCost(Enumeration.Category.MOTORCYCLE.ToString()).ToString();
                txtMechanicsPrice.Text = PaymentUtils.GetCategoryCost(Enumeration.Category.MECHANICS.ToString()).ToString();

                chkEnableInstallments.Checked = ParameterizationUtils.GetBooleanParameterValue(AppConstants.ParameterizationKeys.ENABLE_INSTALLMENTS);
                lblInstallmentsStatus.Text = chkEnableInstallments.Checked ? AppConstants.General.ENABLED_TEXT : AppConstants.General.DISABLED_TEXT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the chkEnableInstallments of the ddlCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void chkEnableInstallments_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblInstallmentsStatus.Text = chkEnableInstallments.Checked ? AppConstants.General.ENABLED_TEXT : AppConstants.General.DISABLED_TEXT;

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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkEnableInstallments.Checked && !PaymentUtils.InstallmentsSet())
                {
                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.ErrorMessage.ERROR_INSTALLMENTS_NOT_SET, Enumeration.WarningType.Danger);
                    return;
                }

                using (GUWork work = new GUWork())
                {
                    category lvCategory = PaymentUtils.GetCategory(Enumeration.Category.LIGHT_VEHICLE.ToString());
                    work.SetEntityType<category>();
                    work.Entity.name = lvCategory.name;
                    work.Entity.description = lvCategory.description;
                    work.Entity.cost = Convert.ToDecimal(txtLightVehiclePrice.Text);
                    work.Update(false);

                    category hvCategory = PaymentUtils.GetCategory(Enumeration.Category.HEAVY_VEHICLE.ToString());
                    work.SetEntityType<category>();
                    work.Entity.name = hvCategory.name;
                    work.Entity.description = hvCategory.description;
                    work.Entity.cost = Convert.ToDecimal(txtHeavyVehiclePrice.Text);
                    work.Update(false);

                    category mtCategory = PaymentUtils.GetCategory(Enumeration.Category.MOTORCYCLE.ToString());
                    work.SetEntityType<category>();
                    work.Entity.name = mtCategory.name;
                    work.Entity.description = mtCategory.description;
                    work.Entity.cost = Convert.ToDecimal(txtMotorcyclePrice.Text);
                    work.Update(false);

                    category mcCategory = PaymentUtils.GetCategory(Enumeration.Category.MECHANICS.ToString());
                    work.SetEntityType<category>();
                    work.Entity.name = mcCategory.name;
                    work.Entity.description = mcCategory.description;
                    work.Entity.cost = Convert.ToDecimal(txtMechanicsPrice.Text);
                    work.Update(false);

                    parameterization_bool installmntsParam = ParameterizationUtils.GetBooleanParameterization(AppConstants.ParameterizationKeys.ENABLE_INSTALLMENTS);
                    work.SetEntityType<parameterization_bool>();
                    work.Entity.parameter_key = installmntsParam.parameter_key;
                    work.Entity.parameter_value = chkEnableInstallments.Checked;
                    work.Update(false);

                    work.Update();

                    ((SiteMaster)Master).ShowAlertNotification(AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION, Enumeration.WarningType.Success);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkBtnEnableInstallment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void lnkBtnEnableInstallments_Click(object sender, EventArgs e)
        {
            try
            {
                uPnlEnableInstallments.Update();
                PageUtils.ClearUIControls(new object[] { txtInstallment1, txtInstallment2, txtInstallment3, txtInstallment4});
                PageUtils.HideUIControls(new object[] { pnlError, pnlSucess });

                FillInstallmentsDataFields();
                btnSaveInstallments.Enabled = true;
                PageUtils.DisplayModal(Page, "modalEnableInstallments", "modalEnableInstallments");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkBtnEnableInstallment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnSaveInstallments_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidatePercentFields())
                {     
                    erroMsg.Text=AppConstants.ErrorMessage.ERROR_INSTALLMENTS_PERCENT_SUM;
                    pnlSucess.Visible = false;
                    pnlError.Visible = true;
                }
                else
                {
                    PaymentUtils.DeleteInstallments();

                    using (GUWork work = new GUWork())
                    {
                        switch (Installments)
                        {
                            case 2:
                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 1;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment1.Text);
                                work.Save(submit: false);

                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 2;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment2.Text);
                                work.Save(submit: false);
                                break;

                            case 3:
                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 1;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment1.Text);
                                work.Save(submit: false);

                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 2;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment2.Text);
                                work.Save(submit: false);

                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 3;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment3.Text);
                                work.Save(submit: false);
                                break;

                            case 4:
                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 1;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment1.Text);
                                work.Save(submit: false);

                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 2;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment2.Text);
                                work.Save(submit: false);

                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 3;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment3.Text);
                                work.Save(submit: false);

                                work.SetEntityType<payment_installment>();
                                work.Entity.id = 4;
                                work.Entity.percentage = Convert.ToDecimal(txtInstallment4.Text);
                                work.Save(submit: false);
                                break;
                        }

                        work.Save();
                        btnSaveInstallments.Enabled = false;

                        successMsg.Text = AppConstants.SucessMessage.SUCCESS_OPERATION_EXECUTION;
                        pnlError.Visible = false;
                        pnlSucess.Visible = true;
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the OnCheckedChanged event of the rbInstallments2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rbInstallments2_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Installments = 2;
                ShowHideInstallmet();
                SetInstallmentsDefaultValues();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the OnCheckedChanged event of the rbInstallments3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rbInstallments3_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Installments = 3;
                ShowHideInstallmet();
                SetInstallmentsDefaultValues();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Handles the OnCheckedChanged event of the rbInstallments4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rbInstallments4_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Installments = 4;
                ShowHideInstallmet();
                SetInstallmentsDefaultValues();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Shows or hides an installment.
        /// </summary>
        private void ShowHideInstallmet()
        {
            try
            {
                switch (Installments)
                {
                    case 2:
                        pnlInstallment1.Visible = true;
                        pnlInstallment2.Visible = true;
                        pnlInstallment3.Visible = false;
                        pnlInstallment4.Visible = false;
                        break;

                    case 3:
                        pnlInstallment1.Visible = true;
                        pnlInstallment2.Visible = true;
                        pnlInstallment3.Visible = true;
                        pnlInstallment4.Visible = false;
                        break;

                    case 4:
                        pnlInstallment1.Visible = true;
                        pnlInstallment2.Visible = true;
                        pnlInstallment3.Visible = true;
                        pnlInstallment4.Visible = true;
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sets the installments default values.
        /// </summary>
        private void SetInstallmentsDefaultValues()
        {
            try
            {
                switch (Installments)
                {
                    case 2:
                        PageUtils.ClearUIControls(new object[] { rbInstallments3, rbInstallments4 });
                        rbInstallments2.Checked = true;
                        txtInstallment1.Text = "50";
                        txtInstallment2.Text = "50";
                        break;

                    case 3:
                        PageUtils.ClearUIControls(new object[] { rbInstallments2, rbInstallments4 });
                        rbInstallments3.Checked = true;
                        txtInstallment1.Text = "50";
                        txtInstallment2.Text = "25";
                        txtInstallment3.Text = "25";
                        break;

                    case 4:
                        PageUtils.ClearUIControls(new object[] { rbInstallments2, rbInstallments3 });
                        rbInstallments4.Checked = true;
                        txtInstallment1.Text = "25";
                        txtInstallment2.Text = "25";
                        txtInstallment3.Text = "25";
                        txtInstallment4.Text = "25";
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sets the installments values.
        /// </summary>
        private void SetInstallmentsValues()
        {
            try
            {
                switch (Installments)
                {
                    case 2:
                        PageUtils.ClearUIControls(new object[] { rbInstallments3, rbInstallments4 });
                        rbInstallments2.Checked = true;
                        payment_installment installment1 = PaymentUtils.GetPaymentInstallment(1);
                        payment_installment installment2 = PaymentUtils.GetPaymentInstallment(2);

                        txtInstallment1.Text = installment1.percentage.ToString();
                        txtInstallment2.Text = installment2.percentage.ToString();
                        break;

                    case 3:
                        PageUtils.ClearUIControls(new object[] { rbInstallments2, rbInstallments4 });
                        rbInstallments3.Checked = true;
                        payment_installment installment1_1 = PaymentUtils.GetPaymentInstallment(1);
                        payment_installment installment2_1 = PaymentUtils.GetPaymentInstallment(2);
                        payment_installment installment3 = PaymentUtils.GetPaymentInstallment(3);

                        txtInstallment1.Text = installment1_1.percentage.ToString();
                        txtInstallment2.Text = installment2_1.percentage.ToString();
                        txtInstallment3.Text = installment3.percentage.ToString();
                        break;

                    case 4:
                        PageUtils.ClearUIControls(new object[] { rbInstallments2, rbInstallments3 });
                        rbInstallments4.Checked = true;
                        payment_installment installment1_2 = PaymentUtils.GetPaymentInstallment(1);
                        payment_installment installment2_2 = PaymentUtils.GetPaymentInstallment(2);
                        payment_installment installment3_1 = PaymentUtils.GetPaymentInstallment(3);
                        payment_installment installment4 = PaymentUtils.GetPaymentInstallment(4);

                        txtInstallment1.Text = installment1_2.percentage.ToString();
                        txtInstallment2.Text = installment2_2.percentage.ToString();
                        txtInstallment3.Text = installment3_1.percentage.ToString();
                        txtInstallment4.Text = installment4.percentage.ToString();
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Validates the percent fiellds.
        /// </summary>
        /// <returns>true if the sum of the fields value is 100; false otherwise.</returns>
        private bool ValidatePercentFields()
        {
            try
            {
                switch (Installments)
                {
                    case 2:
                        decimal installment1 = Convert.ToDecimal(txtInstallment1.Text);
                        decimal installment2 = Convert.ToDecimal(txtInstallment2.Text);
                        return installment1 + installment2 == 100 ? true : false;

                    case 3:
                        decimal installment1_1 = Convert.ToDecimal(txtInstallment1.Text);
                        decimal installment2_1 = Convert.ToDecimal(txtInstallment2.Text);
                        decimal installment3 = Convert.ToDecimal(txtInstallment3.Text);
                        return installment1_1 + installment2_1 + installment3 == 100 ? true : false;

                    case 4:
                        decimal installment1_2 = Convert.ToDecimal(txtInstallment1.Text);
                        decimal installment2_2 = Convert.ToDecimal(txtInstallment2.Text);
                        decimal installment3_1 = Convert.ToDecimal(txtInstallment3.Text);
                        decimal installment4 = Convert.ToDecimal(txtInstallment4.Text);
                        return installment1_2 + installment2_2 + installment3_1 + installment4 == 100 ? true : false;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Fills the installments data fields.
        /// </summary>
        private void FillInstallmentsDataFields()
        {
            try
            {
                if (PaymentUtils.InstallmentsSet())
                {
                    List<payment_installment> paymentInstallments = PaymentUtils.GetPaymentInstallments();

                    Installments = paymentInstallments.Count;
                    ShowHideInstallmet();
                    SetInstallmentsValues();
                }
                else
                {
                    PageUtils.HideUIControls(new object[] { pnlInstallment1,  pnlInstallment2, pnlInstallment3, pnlInstallment4 });
                    PageUtils.ClearUIControls(new object[] { rbInstallments2, rbInstallments3, rbInstallments4 });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}