using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VenturaITC.Files
{
    /// <summary>
    /// File manager class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170830    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class FileManager
    {
        #region Enumeration
        private enum FileType
        {
            pdf,
            excel,
            csv,
            general
        };

        #endregion

        #region Directory
        /// <summary>
        /// Creates a local directory.
        /// </summary>
        /// <param name="path">The directory path.</param>
        public static void CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a local directory.
        /// </summary>
        /// <param name="path">The directory path.</param>
        public static void DeleteDirectory(string path)
        {
            try
            {
                Directory.Delete(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a local directory and all content inside.
        /// </summary>
        /// <param name="path">The directory path.</param>
        public static void DeleteDirectoryAndAllContent(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes all content inside a directory.
        /// </summary>
        /// <param name="path">The directory path.</param>
        public static void EmptyDirectory(string path)
        {
            try
            {
                foreach (string foundFile in Directory.GetFiles(path, "*.*"))
                {
                    if (File.Exists(foundFile))
                    {
                        File.Delete(foundFile);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether a directory exists.
        /// </summary>
        /// <param name="path">The directory path.</param>
        /// <returns>true if the directory exists; otherwise, false.</returns> 
        public static Boolean ExistsDirectory(string path)
        {
            try
            {
                return Directory.Exists(path) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the files count inside a directory.
        /// </summary>
        /// <param name="path">The directory path.</param>
        /// <returns>The number of files inside the given directoty.</returns>
        public static int GetDirectoryFilesCount(string path)
        {
            int count = 0;

            try
            {
                count = Directory.GetFiles(path).Length;
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region File
        /// <summary>
        /// Copies a file.
        /// </summary>
        /// <param name="source">The path of the file to be copied.</param>
        /// <param name="destination">The destination path.</param>
        public static void CopyFile(string source, string destination)
        {
            try
            {
                File.Copy(source, destination);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Copies all files in directory.
        /// </summary>
        /// <param name="source">The source directory.</param>
        /// <param name="destination">The destination directory.</param>
        public static void CopyAllFilesInDirectory(string source, string destination)
        {
            try
            {
                if (destination.Substring(destination.Length - 1, 1) != @"\")
                {
                    destination += @"\";
                }
                foreach (string foundFile in Directory.GetFiles(source, "*.*"))
                {
                    if (File.Exists(foundFile))
                    {
                        File.Copy(foundFile, destination + Path.GetFileName(foundFile));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Moves a file.
        /// </summary>
        /// <param name="source">The path of the file to be moved.</param>
        /// <param name="destination">The destination path.</param>
        public static void MoveFile(string source, string destination)
        {
            try
            {
                File.Move(source, destination);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Moves all files in directory.
        /// </summary>
        /// <param name="source">The source directory.</param>
        /// <param name="destination">The destination directory.</param>
        public static void MoveAllFilesInDirectory(string source, string destination)
        {
            try
            {
                if (destination.Substring(destination.Length - 1, 1) != @"\")
                {
                    destination += @"\";
                }
                foreach (string foundFile in Directory.GetFiles(source, "*.*"))
                {
                    if (File.Exists(foundFile))
                    {
                        File.Move(foundFile, destination + Path.GetFileName(foundFile));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether a file exists.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <returns>true if the file exists; otherwise, false.</returns> 
        public static Boolean ExistsFile(string path)
        {
            try
            {
                return File.Exists(path) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="path">The path of the file to be deleted.</param>      
        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Download
        /// <summary>
        /// Downloads a PDF file.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void DownloadPDF(string path)
        {
            try
            {
                DownloadFile(path, FileType.pdf);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads an excel file.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void DownloadExcel(string path)
        {
            try
            {
                DownloadFile(path, FileType.excel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Generates and downloads an excel file.
        /// </summary>
        /// <param name="dt">The DataTable containing the data.</param>
        /// <param name="fileName">The file name.</param>
        /// <remarks>TODO: Review, there is a bug</remarks>
        public static void DownloadExcel(DataTable dt, string fileName)
        {
            try
            {
                HttpContext.Current.ApplicationInstance.Response.Clear();
                HttpContext.Current.ApplicationInstance.Response.ClearContent();
                HttpContext.Current.ApplicationInstance.Response.ClearHeaders();
                HttpContext.Current.ApplicationInstance.Response.Buffer = true;
                HttpContext.Current.ApplicationInstance.Response.ContentType = "application/ms-excel";
                HttpContext.Current.ApplicationInstance.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                HttpContext.Current.ApplicationInstance.Response.ContentEncoding = Encoding.UTF8;
                HttpContext.Current.ApplicationInstance.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());

                //Sets the table border, cell spacing, border color, font of the text, background, foreground and font.
                HttpContext.Current.ApplicationInstance.Response.Write("<table border='1' bgColor='#FFFFFF'orderColor='#000000' cellSpacing='0' cellPadding='0' " +
                                                                       "style='font-size:9.0pt; font-family:Trebuchet MS; background:white;'>");

                // Writes the header table row.
                HttpContext.Current.ApplicationInstance.Response.Write("<tr style='font-size:10.0pt; height:22px;  color:#FFFFFF; font-family:Trebuchet MS; background:#CD0067;'>");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //Writes the columns header.
                    HttpContext.Current.ApplicationInstance.Response.Write("<th>");
                    HttpContext.Current.ApplicationInstance.Response.Write("<b>");
                    HttpContext.Current.ApplicationInstance.Response.Write(dt.Columns[i].ToString());
                    HttpContext.Current.ApplicationInstance.Response.Write("</b>");
                    HttpContext.Current.ApplicationInstance.Response.Write("</th>");
                }
                HttpContext.Current.ApplicationInstance.Response.Write("</tr>");


                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //Writes the content.
                    HttpContext.Current.ApplicationInstance.Response.Write("<tr>");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        HttpContext.Current.ApplicationInstance.Response.Write("<td>");
                        HttpContext.Current.ApplicationInstance.Response.Write(dt.Rows[i][j].ToString());
                        HttpContext.Current.ApplicationInstance.Response.Write("</td>");
                    }
                }
                HttpContext.Current.ApplicationInstance.Response.Write("</table>");
                HttpContext.Current.ApplicationInstance.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                HttpContext.Current.ApplicationInstance.Response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads any file type.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static void DownloadAnyFile(string path)
        {
            try
            {
                DownloadFile(path, FileType.general);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="path">The file path.</param>
        private static void DownloadFile(string path, FileType fileType)
        {
            try
            {
                FileInfo file = new FileInfo(path);

                if (file.Exists)
                {
                    HttpContext.Current.ApplicationInstance.Response.Clear();
                    HttpContext.Current.ApplicationInstance.Response.ClearContent();
                    HttpContext.Current.ApplicationInstance.Response.ClearHeaders();
                    HttpContext.Current.ApplicationInstance.Response.Buffer = true;

                    switch (fileType)
                    {
                        case FileType.pdf:
                            HttpContext.Current.ApplicationInstance.Response.ContentType = "application/pdf";
                            break;

                        case FileType.excel:
                            HttpContext.Current.ApplicationInstance.Response.ContentType = "application/ms-excel";
                            break;

                        case FileType.general:
                            HttpContext.Current.ApplicationInstance.Response.ContentType = "application/octet-stream";
                            break;

                        default:
                            HttpContext.Current.ApplicationInstance.Response.ContentType = "application/octet-stream";
                            break;
                    }

                    HttpContext.Current.ApplicationInstance.Response.AddHeader("Content-Disposition", "attachment;filename=" + file.Name);
                    HttpContext.Current.ApplicationInstance.Response.AddHeader("Content-Length", file.Length.ToString());
                    HttpContext.Current.ApplicationInstance.Response.ContentEncoding = Encoding.UTF8;
                    HttpContext.Current.ApplicationInstance.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                    HttpContext.Current.ApplicationInstance.Response.TransmitFile(file.FullName);
                    HttpContext.Current.ApplicationInstance.Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    HttpContext.Current.ApplicationInstance.Response.Close();
                }
                else
                {
                    HttpContext.Current.ApplicationInstance.Response.Write("O ficheiro '" + file.FullName + "' não foi encontrado ou não existe.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Report"
        /// <summary>
        /// Generates a PDF Crystal Report.
        /// </summary>
        /// <param name="rpt">The report document.</param>
        /// <param name="path">The path.</param>
        /// <param name="reportName">The report name.</param>
        public static void GeneratePDFReport(ReportDocument rpt, string path, string reportName)
        {
            try
            {
                if (path.Substring(path.Length - 1, 1) != @"\")
                {
                    path += @"\";
                }

                ExportOptions exportOptions;
                DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions formatTypeOptions = new PdfRtfWordFormatOptions();
                diskFileDestinationOptions.DiskFileName = path + reportName;

                exportOptions = rpt.ExportOptions;
                {
                    exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    exportOptions.DestinationOptions = diskFileDestinationOptions;
                    exportOptions.FormatOptions = formatTypeOptions;
                }

                rpt.Export();
                rpt.Close();
                rpt.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Generates an excel Crystal Report.
        /// </summary>
        /// <param name="rpt">The report document.</param>
        /// <param name="path">The path.</param>
        /// <param name="reportName">The report name.</param>
        public static void GenerateExcelReport(ReportDocument rpt, string path, string reportName)
        {
            try
            {
                GenerateReport(rpt, path, reportName, FileType.excel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Generates a CSV Crystal Report.
        /// </summary>
        /// <param name="rpt">The report document.</param>
        /// <param name="path">The path.</param>
        /// <param name="reportName">The report name.</param>
        public static void GenerateCSVReport(ReportDocument rpt, string path, string reportName)
        {
            try
            {
                GenerateReport(rpt, path, reportName, FileType.csv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Generates a Crystal Report.
        /// </summary>
        /// <param name="report">The report document.</param>
        /// <param name="path">The path.</param>
        /// <param name="reportName">The report name.</param>
        /// <param name="reportType">The report type.</param>
        private static void GenerateReport(ReportDocument report, string path, string reportName, FileType reportType)
        {
            try
            {
                //ReportDocument rpt = report;

                //if (path.Substring(path.Length - 1, 1) != @"\")
                //{
                //    path += @"\";
                //}

                //ExportOptions exportOptions;
                //DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
                //PdfRtfWordFormatOptions formatTypeOptions = new PdfRtfWordFormatOptions();
                //diskFileDestinationOptions.DiskFileName = path + reportName;

                //exportOptions = rpt.ExportOptions;
                //{
                //    exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //    exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //    exportOptions.DestinationOptions = diskFileDestinationOptions;
                //    exportOptions.FormatOptions = formatTypeOptions;
                //}
                //switch (reportType)
                //{
                //    case FileType.pdf:
                //        rptExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //        break;

                //    case FileType.excel:
                //        rptExportOptions.ExportFormatType = ExportFormatType.Excel;
                //        break;

                //    case FileType.csv:
                //        rptExportOptions.ExportFormatType = ExportFormatType.CharacterSeparatedValues;
                //        break;

                //    default:
                //        rptExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //        break;
                //}

                //rpt.Export();
                //rpt.Close();
                //rpt.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
