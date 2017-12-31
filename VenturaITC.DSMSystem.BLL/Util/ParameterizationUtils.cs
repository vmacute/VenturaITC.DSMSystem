using System;
using VenturaITC.DSMSystem.BLL.Unit;
using VenturaITC.DSMSystem.MODEL.Class;
using VenturaITC.DSMSystem.MODEL.Entity;

namespace VenturaITC.DSMSystem.BLL.Util
{
    /// Class for parameterization utilities.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20170816    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class ParameterizationUtils
    {
        /// <summary>
        /// Gets a parameterization object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The given parameter key parameterization object.</returns>
        public static parameterization GetParameterization(String key)
        {
            try
            {
                parameterization parametization = UWork<parameterization>.FindByKey(key);

                if (parametization == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_NOT_FOUND_PARAMETERIZATION_DATA);
                }

                return parametization;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the value of a given parameter key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value of a given parameter key.</returns>
        public static string GetParameterValue(String key)
        {
            try
            {
                parameterization parametization = GetParameterization(key);
                return parametization.parameter_value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a parameterization_bool object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The given parameter key parameterization_bool object.</returns>
        public static parameterization_bool GetBooleanParameterization(String key)
        {
            try
            {
                parameterization_bool parametization = UWork<parameterization_bool>.FindByKey(key);

                if (parametization == null)
                {
                    throw new Exception(AppConstants.ExceptionMessage.EXCEP_NOT_FOUND_PARAMETERIZATION_DATA);
                }

                return parametization;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the value (boolean) of a given parameter key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value of a given parameter key.</returns>
        public static bool GetBooleanParameterValue(String key)
        {
            try
            {
                parameterization_bool parametization = GetBooleanParameterization(key);
                return parametization.parameter_value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the document maximum allowed size.
        /// </summary>
        /// <returns>The document maximum allowed size.</returns>
        public static int GetDocumentMaxAllowedSize()
        {
            try
            {
                return Convert.ToInt32(ParameterizationUtils.GetParameterValue(AppConstants.ParameterizationKeys.MAX_DOC_SIZE));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
