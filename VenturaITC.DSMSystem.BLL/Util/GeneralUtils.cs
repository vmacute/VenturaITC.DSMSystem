using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// <summary>
    /// Class for general utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170715    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class GeneralUtils
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// Gets the path of the current user's temporary folder.
        /// </summary>
        /// <returns>The path of the current user's temporary folder.</returns>
        public static string GetUserTempDir()
        {
            try
            {
                return Path.GetTempPath();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the document name of a given document type.
        /// </summary>
        /// <param name="docType">The document type</param>
        /// <returns>The document name.</returns>
        public static string GetDocumentFileName(string docType)
        {
            try
            {
                List<document_type> documents = UWork<document_type>.FindBy(d => d.type == docType);

                if (documents.Count == 0)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_DOCUMENT_TYPES);
                }
                document_type document = documents[0];

                return document.file_name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts a generic List to DataTable
        /// </summary>
        /// <typeparam name="T">The type of the List</typeparam>
        /// <param name="list">The List</param>
        /// <returns>A DataTable containing the list data.</returns>
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            try
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();

                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                foreach (T item in list)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }

                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the selected RadioButton in a group.
        /// </summary>
        /// <param name="radioButtons">The RadioButtons list.</param>
        /// <param name="groupName">The group name</param>
        /// <returns>The selected RadioButton.</returns>
        public static RadioButton GetSelectedRadioButtonInGroup(List<RadioButton> radioButtons, string groupName)
        {
            try
            {
                // ---Usage--
                //List<RadioButton> radioButtons = <ControlName>.Controls.OfType<RadioButton>().ToList();
                //RadioButton selectedRB = GeneralUtils.GetSelectedRadioButtonInGroup(radioButtons, <GroupName>);

                return radioButtons.Where(r => r.GroupName == groupName && r.Checked).Single();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="errorMsg">The error message to log.</param>
        public static void LogError(string errorMsg)
        {
            try
            {
                _logger.Error(String.Format("{0} - {1}", GetLogDetails(), errorMsg));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
            }
        }


        /// <summary>
        /// Logs an error.
        /// </summary>
        /// <param name="errorMsg">The error message to log.</param>
        /// <param name="ex">The exception to log.</param>
        public static void LogError(string errorMsg, Exception ex)
        {
            try
            {
                _logger.Error(String.Format("{0} - {1}", GetLogDetails(), errorMsg), ex);
            }
            catch (Exception exc)
            {
                _logger.Error(ex.Message, exc);
            }
        }

        /// <summary>
        /// Gets the device's name.
        /// </summary>
        /// <returns>The device's name.</returns>
        public static string GetDeviceName()
        {
            try
            {
                return Dns.GetHostName();
            }
            catch (Exception)
            {
                return "Not Found!";
            }
        }


        /// Gets the details for the log as user and Device Name.
        /// </summary>
        /// <returns>The log details.</returns>
        private static string GetLogDetails()
        {
            try
            {
                return String.Format("user: {0}, Device Name: {1}", UserUtils.GetLoggedUserName(), GetDeviceName());
            }
            catch (Exception)
            {
                return "Error getting log details!";
            }
        }

    }
}
