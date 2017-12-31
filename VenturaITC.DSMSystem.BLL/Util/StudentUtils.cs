using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.DAL.Model;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// <summary>
    /// Represents the student utilities class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170701    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class StudentUtils
    {
        /// <summary>
        /// Indicates whether a student number exists into database.
        /// </summary>
        /// <param name="number">The student number.</param>
        /// <returns>True if exists; False otherwise.</returns>
        public static bool ExistsStudentNumber(int number)
        {
            try
            {
                student student = UWork<student>.FindByKey(number);

                if (student != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the student first name from a given full name.
        /// </summary>
        /// <param name="fullName">The student full name.</param>
        /// <returns>The student first name </returns>
        public static string GetFirstName(string fullName)
        {
            try
            {
                string[] names = fullName.Split(' ');
                return names[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the student last name from a given full name.
        /// </summary>
        /// <param name="fullName">The student full name.</param>
        /// <returns>The student last name </returns>
        public static string GetLastName(string fullName)
        {
            try
            {
                string[] names = fullName.Split(' ');
                return names[names.Length - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Converts a student number from string to int.
        /// </summary>
        /// <param name="studentNumber">The student number string representation.</param>
        /// <returns>The student number converted to int.</returns>
        public static int GetStudentNumber(string studentNumber)
        {
            try
            {
                return Convert.ToInt32(studentNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the student object.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <returns>The student object.</returns>
        public static student GetStudent(int studentNumber)
        {
            try
            {
                student student = UWork<student>.FindByKey(studentNumber);

                if (student == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_DATA);
                }

                return student;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the active Students.
        /// </summary>
        /// <returns>The active Students list.</returns>
        public static List<student> GetActiveStudents()
        {
            try
            {
                List<student> students = UWork<student>.FindBy(x => x.status == Enumeration.DatabaseDataStatus.ACTIVE.ToString());
                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a list of students with associated registration data.
        /// </summary>
        /// <param name="paymentStatus">The payment status.</param>
        /// <returns>A DataTable containing the list of students with associated registration data. </returns>
        public static DataTable GetStudentListWithAssociatedRegistration_Excel(string paymentStatus = "NONE")
        {
            DataTable table = new DataTable();

            try
            {
                //Add the collumns.
                table.Columns.Add("NUMERO", typeof(int));
                table.Columns.Add("TIPO", typeof(string));
                table.Columns.Add("NOME", typeof(string));
                table.Columns.Add("NUMERO_BI", typeof(string));
                table.Columns.Add("CATEGORIA", typeof(string));
                table.Columns.Add("DATA_INSCRICAO", typeof(DateTime));
           
                //Add the data.
                List<student> students = GetActiveStudents();

                if (paymentStatus == Enumeration.PaymentStatus.FINISHED.ToString())
                {
                    students = GetStudentsWithFinishedPayments();
                }

                if (paymentStatus == Enumeration.PaymentStatus.NON_FINISHED.ToString())
                {
                    students = GetStudentsWithNonFinishedPayments();
                }

                foreach (student student in students)
                {
                    student_enrollment registration = GetStudentRegistration(student.number);
                    student_documentation documentation = GetStudentDocument(student.number, Enumeration.DocumentType.PICTURE.ToString());
                    category category = UWork<category>.FindByKey(registration.category);
                    user user = UWork<user>.FindByKey(registration.enrollment_user);

                    DataRow row = table.NewRow();

                    row["NUMERO"] = student.number;
                    row["TIPO"] = student.type_description;
                    row["NOME"] = student.full_name;
                    row["NUMERO_BI"] = student.ID_number;
                    row["CATEGORIA"] = category.description;
                    row["DATA_INSCRICAO"] = registration.enrollment_date;
                   
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
        /// Gets a list of students with associated registration data.
        /// </summary>
        /// <param name="paymentStatus">The payment status.</param>
        /// <returns>A DataTable containing the list of students with associated registration data. </returns>
        public static DataTable GetStudentListWithAssociatedRegistration(string paymentStatus = "NONE")
        {
            DataTable table = new DataTable();

            try
            {
                //Add the collumns.
                table.Columns.Add("student_number", typeof(int));
                table.Columns.Add("student_type", typeof(string));
                table.Columns.Add("full_name", typeof(string));
                table.Columns.Add("birth_date", typeof(DateTime));
                table.Columns.Add("marital_status", typeof(string));
                table.Columns.Add("gender", typeof(string));
                table.Columns.Add("place_of_birth", typeof(string));
                table.Columns.Add("province_of_birth", typeof(string));
                table.Columns.Add("fathers_name", typeof(string));
                table.Columns.Add("mothers_name", typeof(string));
                table.Columns.Add("address", typeof(string));
                table.Columns.Add("ID_number", typeof(string));
                table.Columns.Add("ID_issuance_place", typeof(string));
                table.Columns.Add("ID_issuance_date", typeof(DateTime));
                table.Columns.Add("ID_expiry_date", typeof(DateTime));
                table.Columns.Add("academic_level", typeof(string));
                table.Columns.Add("job_title", typeof(string));
                table.Columns.Add("phone_number", typeof(string));
                table.Columns.Add("cell_phone1", typeof(string));
                table.Columns.Add("cell_phone2", typeof(string));
                table.Columns.Add("email", typeof(string));
                table.Columns.Add("picture", typeof(byte[]));
                table.Columns.Add("category", typeof(string));
                table.Columns.Add("enrollment_date", typeof(DateTime));
                table.Columns.Add("enrollment_user", typeof(string));

                //Add the data.
                List<student> students = GetActiveStudents();

                if (paymentStatus == Enumeration.PaymentStatus.FINISHED.ToString())
                {
                    students = GetStudentsWithFinishedPayments();
                }

                if (paymentStatus == Enumeration.PaymentStatus.NON_FINISHED.ToString())
                {
                    students = GetStudentsWithNonFinishedPayments();
                }

                foreach (student student in students)
                {
                    student_enrollment registration = GetStudentRegistration(student.number);
                    student_documentation documentation = GetStudentDocument(student.number, Enumeration.DocumentType.PICTURE.ToString());
                    category category = UWork<category>.FindByKey(registration.category);
                    user user = UWork<user>.FindByKey(registration.enrollment_user);

                    DataRow row = table.NewRow();

                    row["student_number"] = student.number;
                    row["student_type"] = student.type_description;
                    row["full_name"] = student.full_name;
                    row["birth_date"] = student.birth_date;
                    row["marital_status"] = student.marital_status_description;
                    row["gender"] = student.gender_description;
                    row["place_of_birth"] = student.place_of_birth;
                    row["province_of_birth"] = student.number;
                    row["fathers_name"] = student.fathers_name;
                    row["mothers_name"] = student.mothers_name;
                    row["address"] = student.address;
                    row["ID_number"] = student.ID_number;
                    row["ID_issuance_place"] = student.ID_issuance_place;
                    row["ID_issuance_date"] = student.ID_issuance_date;
                    row["ID_expiry_date"] = student.ID_expiry_date;
                    row["academic_level"] = student.academic_level;
                    row["job_title"] = student.job_title;
                    row["phone_number"] = student.phone_number;
                    row["cell_phone1"] = student.cell_phone1;
                    row["cell_phone2"] = student.cell_phone2;
                    row["email"] = student.email;
                    row["picture"] = documentation.document_content;
                    row["category"] = category.description;
                    row["enrollment_date"] = registration.enrollment_date;
                    row["enrollment_user"] = user.full_name;

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
        /// Gets a student with associated registration data.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <returns>A DataTable containing a student  with associated registration data.</returns>
        public static DataTable GetStudentWithAssociatedRegistration(int studentNumber)
        {
            DataTable table = new DataTable();

            try
            {
                student student = GetStudent(studentNumber);
                student_enrollment registration = GetStudentRegistration(student.number);
                student_documentation documentation = GetStudentDocument(student.number, Enumeration.DocumentType.PICTURE.ToString());
                category category = UWork<category>.FindByKey(registration.category);
                user user = UWork<user>.FindByKey(registration.enrollment_user);

                //Add the collumns.
                table.Columns.Add("student_number", typeof(int));
                table.Columns.Add("student_type", typeof(string));
                table.Columns.Add("full_name", typeof(string));
                table.Columns.Add("birth_date", typeof(DateTime));
                table.Columns.Add("marital_status", typeof(string));
                table.Columns.Add("gender", typeof(string));
                table.Columns.Add("place_of_birth", typeof(string));
                table.Columns.Add("province_of_birth", typeof(string));
                table.Columns.Add("fathers_name", typeof(string));
                table.Columns.Add("mothers_name", typeof(string));
                table.Columns.Add("address", typeof(string));
                table.Columns.Add("ID_number", typeof(string));
                table.Columns.Add("ID_issuance_place", typeof(string));
                table.Columns.Add("ID_issuance_date", typeof(DateTime));
                table.Columns.Add("ID_expiry_date", typeof(DateTime));
                table.Columns.Add("academic_level", typeof(string));
                table.Columns.Add("job_title", typeof(string));
                table.Columns.Add("phone_number", typeof(string));
                table.Columns.Add("cell_phone1", typeof(string));
                table.Columns.Add("cell_phone2", typeof(string));
                table.Columns.Add("email", typeof(string));
                table.Columns.Add("picture", typeof(byte[]));
                table.Columns.Add("category", typeof(string));
                table.Columns.Add("enrollment_date", typeof(DateTime));
                table.Columns.Add("enrollment_user", typeof(string));

                //Add the data.
                DataRow row = table.NewRow();
                row["student_number"] = student.number;
                row["student_type"] = student.type_description;
                row["full_name"] = student.full_name;
                row["birth_date"] = student.birth_date;
                row["marital_status"] = student.marital_status_description;
                row["gender"] = student.gender_description;
                row["place_of_birth"] = student.place_of_birth;
                row["province_of_birth"] = student.number;
                row["fathers_name"] = student.fathers_name;
                row["mothers_name"] = student.mothers_name;
                row["address"] = student.address;
                row["ID_number"] = student.ID_number;
                row["ID_issuance_place"] = student.ID_issuance_place;
                row["ID_issuance_date"] = student.ID_issuance_date;
                row["ID_expiry_date"] = student.ID_expiry_date;
                row["academic_level"] = student.academic_level;
                row["job_title"] = student.job_title;
                row["phone_number"] = student.phone_number;
                row["cell_phone1"] = student.cell_phone1;
                row["cell_phone2"] = student.cell_phone2;
                row["email"] = student.email;
                row["picture"] = documentation.document_content;
                row["category"] = category.description;
                row["enrollment_date"] = registration.enrollment_date;
                row["enrollment_user"] = user.full_name;

                table.Rows.Add(row);

                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the student registration.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <returns>The student registration object.</returns>
        public static student_enrollment GetStudentRegistration(int studentNumber)
        {
            try
            {
                List<student_enrollment> studentRegistrations = UWork<student_enrollment>.FindBy(s => s.student_number == studentNumber);

                if (studentRegistrations.Count == 0)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_REGISTRATION);
                }

                return studentRegistrations.First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the student's category.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <returns>The student category object.</returns>
        public static category GetStudentCategory(int studentNumber)
        {
            try
            {
                student_enrollment studentRegistration = GetStudentRegistration(studentNumber);
                return PaymentUtils.GetCategory(studentRegistration.category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the students with non finished payments.
        /// </summary>
        /// <returns>The list of students with non finished payments.</returns>
        public static List<student> GetStudentsWithNonFinishedPayments()
        {
            try
            {
                List<student> students = GetActiveStudents();

                foreach (student student in students.ToList())
                {
                    if (PaymentUtils.IsStudentPaymentFinished(student.number))
                    {
                        students.Remove(student);
                    }
                }

                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the students with finished payments.
        /// </summary>
        /// <returns>The list of students with finished payments.</returns>
        public static List<student> GetStudentsWithFinishedPayments()
        {
            try
            {
                List<student> students = GetActiveStudents();

                foreach (student student in students.ToList())
                {
                    if (!PaymentUtils.IsStudentPaymentFinished(student.number))
                    {
                        students.Remove(student);
                    }
                }

                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="student">The updated/modified student object</param>
        public static void UpdateStudent(student student)
        {
            try
            {
                using (UWork<student> work = new UWork<student>())
                {
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

                    work.Update();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a student document.
        /// </summary>
        /// <param name="studentNumber">The student number</param>
        /// <param name="docType">The document type</param>
        /// <returns>The student document</returns>
        public static student_documentation GetStudentDocument(int studentNumber, string docType)
        {
            try
            {
                List<student_documentation> studentDocs = UWork<student_documentation>.FindBy(s => s.student_number == studentNumber && s.document_type == docType);

                if (studentDocs.Count == 0)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_DOCUMENTATION);
                }

                student_documentation studentDocumentation = studentDocs.First();

                return studentDocumentation;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the student documentation.
        /// </summary>
        /// <param name="studentNumber">The student number</param>
        /// <returns>The student documentation</returns>
        public static List<student_documentation> GetStudentDocumentation(int studentNumber)
        {
            try
            {
                List<student_documentation> studentDocs = UWork<student_documentation>.FindBy(s => s.student_number == studentNumber);

                if (studentDocs.Count == 0)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_DOCUMENTATION);
                }

                return studentDocs;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
