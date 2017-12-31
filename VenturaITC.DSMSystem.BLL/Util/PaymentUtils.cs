using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;
using VenturaITC.VenturaITC.DSMSystem.BLL.Unit;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// Class for payment utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170711    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class PaymentUtils
    {
        /// <summary>
        /// Gets a category.
        /// </summary>
        /// <param name="categoryName">The category name.</param>
        /// <returns>The category object.</returns>
        public static category GetCategory(string categoryName)
        {
            try
            {
                category category = UWork<category>.FindByKey(categoryName);

                if (category == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_CATEGORIES);
                }

                return category;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the category cost.
        /// </summary>
        /// <param name="categoryName">The category name.</param>
        /// <returns>The category cost if found; -1 otherwise.</returns>
        public static decimal GetCategoryCost(string categoryName)
        {
            try
            {
                category category = GetCategory(categoryName);

                if (category == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_CATEGORIES);
                }

                return category.cost;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets an installment's amount.
        /// </summary>
        /// <param name="installmentNumber">The installment's number.</param>
        /// <param name="totalAmount">The cost/total amount.</param>
        /// <returns>The installment's amount if found.</returns>
        public static decimal GetInstallmentAmount(int installmentNumber, decimal totalAmount)
        {
            try
            {
                payment_installment installment = GetPaymentInstallment(installmentNumber);
                return MathematicsUtils.GetValueByPercentage(totalAmount, installment.percentage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether a receipt number exists into database.
        /// </summary>
        /// <param number="cost">The receipt number.</param>
        /// <returns>True if exists; False otherwise.</returns>
        public static bool ExistsReceiptNumber(int number)
        {
            try
            {
                student_payment studentPayment = UWork<student_payment>.FindByKey(number);

                if (studentPayment != null)
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
        /// Indicates whether the payment installments are set.
        /// </summary>
        /// <returns>true if the installments are set; false otherwise.</returns>
        public static bool InstallmentsSet()
        {
            try
            {
                List<payment_installment> installments = GetPaymentInstallments();
                return installments.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the payments installments.
        /// </summary>
        /// <returns>The payment installments.</returns>
        public static List<payment_installment> GetPaymentInstallments()
        {
            try
            {
                List<payment_installment> installments = UWork<payment_installment>.GetAll().OrderBy(o => o.id).ToList();
                return installments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a payments installment.
        /// </summary>
        /// <param name="number">The installment number</param>
        /// <returns>The payment installment</returns>
        public static payment_installment GetPaymentInstallment(int number)
        {
            try
            {
                payment_installment installment = GetPaymentInstallments().Where(i => i.id == number).FirstOrDefault();

                if (installment == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_NOT_FOUND_INSTALLMENT_INFO);
                }

                return installment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes payment installments.
        /// </summary>
        public static void DeleteInstallments()
        {
            try
            {
                List<payment_installment> installments = GetPaymentInstallments();
                using (GUWork work = new GUWork())
                {
                    foreach (payment_installment installment in installments)
                    {
                        work.SetEntityType<payment_installment>();
                        work.Entity.id = installment.id;
                        work.Entity.percentage = installment.percentage;
                        work.Delete(submit: false);

                        if (installment == installments.Last())
                        {
                            work.Delete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether a student has finished the payments.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <returns>true if the student has finished the payments; false otherwise.</returns>
        public static bool IsStudentPaymentFinished(int studentNumber)
        {
            try
            {
                List<student_payment> studentPayments = GetStudentPayments(studentNumber);

                student_payment studentPayment = studentPayments.Last();
                student_enrollment registration = StudentUtils.GetStudentRegistration(studentNumber);

                if (studentPayment.total_paid_amount == GetCategoryCost(registration.category) && studentPayment.remaining_amount == 0)
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

        ///// <summary>
        ///// Gets the fine amount.
        ///// </summary>
        ///// <param name="studentNumber">The student number.</param>
        ///// <returns>The fine amount</returns>
        //public static decimal GetFineAmount(int studentNumber)
        //{
        //    decimal amount = 0;

        //    try
        //    {
        //        List<student_payment> studentPayments = GetStudentPayments(studentNumber);

        //        CheckStudentPayments(studentPayments);

        //        student_payment studentPayment = studentPayments.Last();
        //        student_enrollment registration = StudentUtils.GetStudentRegistration(studentNumber);
        //        category category = UWork<category>.FindByKey(registration.category);
        //        List<PaymentFine> fines = UWork<PaymentFine>.FindBy(x => x.category == registration.category).OrderByDescending(x => x.working_days).ToList();

        //        int daysDiff = DateUtils.GetWorkingDaysRange(studentPayment.date, DateTime.Now);

        //        foreach (PaymentFine fine in fines)
        //        {
        //            if (daysDiff >= fine.working_days)
        //            {
        //                amount = MathematicsUtils.GetValueByPercentage(category.cost, fine.percentage);
        //                return amount;
        //            }
        //        }

        //        return amount;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// Gets the student payments list.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <returns>The student payments.</returns>
        public static List<student_payment> GetStudentPayments(int studentNumber)
        {
            try
            {
                List<student_payment> studentPayments = UWork<student_payment>.FindBy(x => x.student_number == studentNumber).OrderBy(x => x.date).ToList();

                if (studentPayments.Count == 0)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_ERROR_GETTING_STUDENT_PAYMENT_DATA);
                }

                return studentPayments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the student's last payment.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <returns>The student's last payment.</returns>
        public static student_payment GetStudentLastPayment(int studentNumber)
        {
            try
            {
                List<student_payment> studentPayments = GetStudentPayments(studentNumber);
                return studentPayments.Last();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the payments minimum amount.
        /// </summary>
        /// <param name="studentNumber">The student number.</param>
        /// <param name="currInstallment">The current installment's amount.</param>
        /// <returns>The payment minimum amount.</returns>
        public static decimal GetPaymentMinAmount(int studentNumber, int currInstallment)
        {
            try
            {
                category category = StudentUtils.GetStudentCategory(studentNumber);

                decimal remainingAmount = GetStudentLastPayment(studentNumber).remaining_amount;
                decimal currdInstallmentAmount = GetInstallmentAmount(currInstallment, category.cost);

                if (currdInstallmentAmount <= remainingAmount)
                {
                    return currdInstallmentAmount;
                }
                else
                {
                    return remainingAmount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
