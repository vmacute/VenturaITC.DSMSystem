using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VenturaITC.DSMSystem.MODEL.Class;

namespace VenturaITC.DSMSystem.Pages
{
    /// <summary>
    /// Handles the PDF visulization functionality.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170717    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class PDFViewer : Page
    {
        /// <summary>
        /// Handles the Load event of the Page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Session[AppConstants.SessionVariables.FILE_PATH].ToString();

            if (filePath == null)
            {
                throw new Exception(AppConstants.ExceptionMessage.EXCEP_FILE_NOT_FOUND);
            }

            FileInfo file = new FileInfo(filePath);

            if (file.Exists)
            {

                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content -Disposition", "inline;filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "Application/pdf";
                Response.ContentEncoding = Encoding.UTF8;
                Response.BinaryWrite(Encoding.UTF8.GetPreamble());
                Response.TransmitFile(file.FullName);
                Response.Flush();
                Response.Close();

            }
            else
            {
                Response.Write(AppConstants.ExceptionMessage.EXCEP_FILE_NOT_FOUND + "-" + filePath);
            }
        }
    }
}