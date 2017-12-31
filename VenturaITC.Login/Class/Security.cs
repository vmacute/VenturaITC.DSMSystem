using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VenturaITC.Login.Class
{
    /// <summary>
    /// Handles security issues.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170831    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class Security
    {
        /// <summary>
        /// Hashs a password using the SHA-256 algoritm.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>The SHA-256 hash of the given username and password</returns>
        /// <remarks>The final user's password is based on the concatenaion of the  username and password.</remarks>
        public static byte[] HashPassword(string username, string password)
        {
            try
            {
                SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
                return sha.ComputeHash(Encoding.UTF8.GetBytes(username + password));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifies the user's password.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="userPassword">The user's password.</param>
        /// <param name="dbPassword">The user's password stored in the database byte array.</param>
        /// <returns>true if the given user's passwords and that one stored in the database are equal, otherwise false.</returns>
        public static bool VerifyPassword(string username, string password, byte[] dbPassword)
        {
            try
            {
                byte[] userPassword = HashPassword(username, password);
        
                if (userPassword.Length != dbPassword.Length)
                {
                    return false;
                }

                for (int i = 0; i < userPassword.Length; i++)
                {
                    if (userPassword[i] != dbPassword[i])
                    {
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
        /// Gets the maximum login attempts.
        /// </summary>
        /// <returns>The maximum login attempts</returns>
        public static int  GetMaxLoginAttempts()
        {
            return 3;
        }

        /// <summary>
        /// Gets the minimum password length.
        /// </summary>
        /// <returns>The minimum password length.</returns>
        public static int GetMinPasswordLength()
        {
            return 8;
        }

        /// <summary>
        /// Gets the password's life time.
        /// </summary>
        /// <returns>The password's life time.</returns>
        /// <remarks>The password's life time is given in days.</remarks>
        public static int GetPasswordLifeTime()
        {
            return 30;
        }
    }
}
