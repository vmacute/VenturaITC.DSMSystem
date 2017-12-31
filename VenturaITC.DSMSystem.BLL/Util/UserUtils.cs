using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VenturaITC.DSMSystem.BLL.Class;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;
using VenturaITC.Login.Class;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// <summary>
    /// Class for user utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170831    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class UserUtils
    {
        /// <summary>
        /// Gets an user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The user object.</returns>
        public static user GetUser(string username)
        {
            try
            {
                user user = UWork<user>.FindByKey(username);

                if (user == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_NOT_FOUND_USER);
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <returns>The user's list.</returns>
        public static List<user> GetAllUsers()
        {
            try
            {
                List<user> users = UWork<user>.GetAll().OrderBy(o => o.username).ToList();
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all active Users.
        /// </summary>
        /// <returns>The active user's list.</returns>
        public static List<user> GetActiveUsers()
        {
            try
            {
                List<user> users = GetAllUsers().Where(x => x.status == Enumeration.DatabaseDataStatus.ACTIVE.ToString()).ToList();
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all active Users.
        /// </summary>
        /// <returns>The active user's list.</returns>
        public static List<user> GetDeletedUsers()
        {
            try
            {
                List<user> users = GetAllUsers().Where(x => x.status == Enumeration.DatabaseDataStatus.DELETED.ToString()).ToList();
                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Indicates whether a user exists or is active. 
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>true if the user exists or is active; false otherwise.</returns>
        public static bool ExistsOrActiveUser(string username)
        {
            try
            {
                user user = UWork<user>.FindBy(x => x.username == username && x.status == Enumeration.DatabaseDataStatus.ACTIVE.ToString()).FirstOrDefault();
                return user != null ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Indicates whether a user must change the password. 
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>true if the user must change the password; false otherwise.</returns>
        public static bool MustChangePassword(string username)
        {
            try
            {
                //System admin user never change password
                if (username == AppConstants.General.SYS_ADMIN_USERNAME)
                {
                    return false;
                }

                user user = GetUser(username);

                if (user.must_change_password || user.last_password_change == null)
                {
                    return true;
                }

                if (user.last_password_change != null)
                {
                    int daysDiff = DateUtils.GetDaysRange((DateTime)user.last_password_change, DateTime.Now);

                    if (daysDiff >= Security.GetPasswordLifeTime())
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates an user
        /// </summary>
        /// <param name="user">The user.</param>
        public static void UpdateUser(user user)
        {
            try
            {
                using (UWork<user> work = new UWork<user>())
                {
                    work.Entity.username = user.username;
                    work.Entity.full_name = user.full_name;
                    work.Entity.cell_phone = user.cell_phone;
                    work.Entity.email = user.email;
                    work.Entity.role = user.role;
                    work.Entity.locked = user.locked;
                    work.Entity.disabled = user.disabled;
                    work.Entity.password = user.password;
                    work.Entity.must_change_password = user.must_change_password;
                    work.Entity.last_password_change = user.last_password_change;
                    work.Entity.logged = user.logged;
                    work.Entity.last_login = user.last_login;
                    work.Entity.current_login_attempts = user.current_login_attempts;
                    work.Entity.registration_date = user.registration_date;
                    work.Entity.registration_user = user.registration_user;
                    work.Entity.status = user.status;
                    work.Update();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Attempts the user login
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <param name="shouldLockout">The user lockout option</param>
        /// <returns>The status of the login attempt.</returns>
        public static SignInStatus AttemptLogIn(string username, string password, bool shouldLockout)
        {
            try
            {
                if (!ExistsOrActiveUser(username))
                {
                    return SignInStatus.InvalidUserName;
                }

                user user = GetUser(username);

                //Update login attempts
                user.current_login_attempts += 1;
                UpdateUser(user);
            
                if (user.locked)
                {
                    return SignInStatus.LockedOut;
                }

                if (user.disabled)
                {
                    return SignInStatus.Disabled;
                }

                if (shouldLockout)
                {
                    if (user.current_login_attempts >= Security.GetMaxLoginAttempts())
                    {
                        user.locked = true;
                        UpdateUser(user);

                        return SignInStatus.LockedOut;
                    }
                }

                if (Security.VerifyPassword(username, password, user.password))
                {
                    user.last_login = DateTime.Now;
                    //Reset login attempts
                    user.current_login_attempts =0;
                    UpdateUser(user);
                    return SignInStatus.Success;
                }

                if (!Security.VerifyPassword(username, password, user.password))
                {
                    return SignInStatus.IncorrectPassword;
                }

                return SignInStatus.failure;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Performs the password change
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="newPassword">The new password</param>
        public static void ChangePassword(string username, string newPassword)
        {
            try
            {
                user user = GetUser(username);

                user.password = Security.HashPassword(username, newPassword);
                user.must_change_password = false;
                user.last_password_change = DateTime.Now;
                user.logged = true;

                UpdateUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Gets the username of the logged user.
        /// </summary>
        /// <returns>The username of the logged user</returns>
        public static string GetLoggedUserName()
        {
            try
            {
                string username = HttpContext.Current.Session[AppConstants.SessionVariables.USERNAME].ToString();

                if (username == string.Empty)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_NOT_FOUND_USERNAME);
                }

                return username;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the role of the logged user.
        /// </summary>
        /// <returns>The role of the logged user</returns>
        public static string GetLoggedUserRole()
        {
            try
            {
                string role = HttpContext.Current.Session[AppConstants.SessionVariables.USER_ROLE].ToString();

                if (role == string.Empty)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_NOT_FOUND_USER_ROLE);
                }

                return role;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the full name of the logged user.
        /// </summary>
        /// <returns>The full name of the logged user</returns>
        public static string GetLoggedUserFullName()
        {
            try
            {
                string userFullName = HttpContext.Current.Session[AppConstants.SessionVariables.USER_FULL_NAME].ToString();

                if (userFullName == string.Empty)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_NOT_FOUND_USER_FULL_NAME);
                }

                return userFullName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Sets the user session data.
        /// </summary>
        /// <param name="user">The username.</param>
        public static void SetUserSessionData(string username)
        {
            try
            {
                user user = GetUser(username);
                HttpContext.Current.Session[AppConstants.SessionVariables.USERNAME] = user.username;
                HttpContext.Current.Session[AppConstants.SessionVariables.USER_ROLE] = user.role;
                HttpContext.Current.Session[AppConstants.SessionVariables.USER_FULL_NAME] = user.full_name;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}