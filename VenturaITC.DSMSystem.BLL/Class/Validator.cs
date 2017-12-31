using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VenturaITC.DSMSystem.BLL.Util;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.Login.Class;

namespace VenturaITC.DSMSystem.BLL.Class
{
    /// <summary>
    /// Represents the validations class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170701    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class Validator
    {
        /// <summary>
        /// Validates a password enforcing the 1+ number/1+ lowercase/1+ uppercase rule and also the size between 8-15.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>true if the password is valid, false otherwise.</returns>
        public static bool ValidatePassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";

            try
            {
                return Regex.Match(password, pattern).Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Indicates whether an email is valid.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>true if the email is valid, false otherwise.</returns>
        public static bool IsEmailValid(string email)
        {
            string pattern = @"'\+([-+.'](\w)+)*@\w+([-.]\w+)*\.\w+([-.]'\'w+)*";

            try
            {
                return Regex.Match(email, pattern).Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether a given document size is allowed.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>true if the document size is allowed; false otherwise.</returns>
        public static bool IsDocumentSizeAllowed(int size)
        {
            try
            {
                int maxSize = ParameterizationUtils.GetDocumentMaxAllowedSize();
                return size <= maxSize ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validates the password length
        /// </summary>
        /// <param name="password">The password</param>
        ///   <param name="password">The password confirmation</param>
        /// <returns>true if the password confirmation is successful; false otherwise.</returns>
        public static bool PasswordConfirm(string password, string passwordConfirm)
        {
            try
            {
                return password == passwordConfirm ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether the user's new password is the same with the new one.
        /// </summary>
        /// <param name="oldPassword">The old password</param>
        ///  <param name="newPassword">The new password</param>
        /// <returns>true if the user's new password is the same with the new one.; false otherwise.</returns>
        public static bool IsCurrentPassword(string oldPassword, string newPassword)
        {
            try
            {
                return oldPassword == newPassword ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
