using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenturaITC.Login.Class
{
    /// <summary>
    /// Possible results from a sign in attempt.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170831    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public enum SignInStatus
    {

        /// <summary>
        /// Sign in was successful
        /// </summary>
        Success = 0,

        /// <summary>
        /// Sign in was failed
        /// </summary>
        failure = 1,

        /// <summary>
        /// The username is invalid
        /// </summary>
        InvalidUserName = 2,

        /// <summary>
        /// The password is incorrect.
        /// </summary>   
        IncorrectPassword = 3,

        /// <summary>
        /// User locked out
        /// </summary>   
        LockedOut = 4,

        /// <summary>
        /// User disabled
        /// </summary>   
        Disabled = 5
    }
}
