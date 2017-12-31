using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VenturaITC.DSMSystem.Util
{
    /// <summary>
    /// Class for Page utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170703   Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class PageUtils
    {
        /// <summary>
        /// Displays a modal popup
        /// </summary>
        /// <param name="page">The page object that is registering the client script block</param>
        /// <param name="key">A unique identifier for the script block</param>
        /// <param name="script">The script to register</param>
        public static void DisplayModal(Page page, string key, string script)
        {
            try
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), key, "$('#" + script + "').modal();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Opens a new browser's tab.
        /// </summary>
        /// <param name="page">The page object that is registering the script block</param>
        /// <param name="url">The URL/param>
        public static void OpenNewBrowserTab(Page page, string url)
        {
            try
            {
                ScriptManager.RegisterStartupScript(page, page.GetType(), "NewTab", "window.open('" + url + "','_blank');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clears  user Interface controls.
        /// </summary>
        /// <param name="controls">The user Interface controls array.</param>
        public static void ClearUIControls(Object[] controls)
        {
            try
            {
                foreach (Object control in controls)
                {
                    if (Object.ReferenceEquals(control.GetType(), typeof(TextBox)))
                    {
                        ((TextBox)control).Text = String.Empty;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(Label)))
                    {
                        ((Label)control).Text = String.Empty;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(CheckBox)))
                    {
                        ((CheckBox)control).Checked = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                    {
                        ((RadioButton)control).Checked = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(DropDownList)))
                    {
                        ((DropDownList)control).SelectedIndex = 0;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(GridView)))
                    {
                        ((GridView)control).DataSource = new DataTable();
                        ((GridView)control).DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Enables user Interface controls.
        /// </summary>
        /// <param name="controls">The user Interface controls array.</param>
        public static void EnableUIControls(Object[] controls)
        {
            try
            {
                foreach (Object control in controls)
                {
                    if (Object.ReferenceEquals(control.GetType(), typeof(TextBox)))
                    {
                        ((TextBox)control).Enabled = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(CheckBox)))
                    {
                        ((CheckBox)control).Enabled = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                    {
                        ((RadioButton)control).Enabled = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(DropDownList)))
                    {
                        ((DropDownList)control).Enabled = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(Button)))
                    {
                        ((Button)control).Enabled = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(GridView)))
                    {
                        ((GridView)control).Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Disables user Interface controls.
        /// </summary>
        /// <param name="controls">The user Interface controls array.</param>
        public static void DisableUIControls(Object[] controls)
        {
            try
            {
                foreach (Object control in controls)
                {
                    if (Object.ReferenceEquals(control.GetType(), typeof(TextBox)))
                    {
                        ((TextBox)control).Enabled = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(CheckBox)))
                    {
                        ((CheckBox)control).Enabled = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                    {
                        ((RadioButton)control).Enabled = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(Button)))
                    {
                        ((Button)control).Enabled = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(DropDownList)))
                    {
                        ((DropDownList)control).Enabled = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(GridView)))
                    {
                        ((GridView)control).Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Shows user Interface controls.
        /// </summary>
        /// <param name="controls">The user Interface controls array.</param>
        public static void ShowUIControls(Object[] controls)
        {
            try
            {
                foreach (Object control in controls)
                {
                    if (Object.ReferenceEquals(control.GetType(), typeof(TextBox)))
                    {
                        ((TextBox)control).Visible = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(CheckBox)))
                    {
                        ((CheckBox)control).Visible = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                    {
                        ((RadioButton)control).Visible = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(Button)))
                    {
                        ((Button)control).Visible = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(DropDownList)))
                    {
                        ((DropDownList)control).Visible = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(GridView)))
                    {
                        ((GridView)control).Visible = true;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(Panel)))
                    {
                        ((Panel)control).Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Shows user Interface controls.
        /// </summary>
        /// <param name="controls">The user Interface controls array.</param>
        public static void HideUIControls(Object[] controls)
        {
            try
            {
                foreach (Object control in controls)
                {
                    if (Object.ReferenceEquals(control.GetType(), typeof(TextBox)))
                    {
                        ((TextBox)control).Visible = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(CheckBox)))
                    {
                        ((CheckBox)control).Visible = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(RadioButton)))
                    {
                        ((RadioButton)control).Visible = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(DropDownList)))
                    {
                        ((DropDownList)control).Visible = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(Button)))
                    {
                        ((Button)control).Visible = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(GridView)))
                    {
                        ((GridView)control).Visible = false;
                    }

                    if (Object.ReferenceEquals(control.GetType(), typeof(Panel)))
                    {
                        ((Panel)control).Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}