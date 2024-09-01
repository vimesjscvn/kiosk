namespace Core.Common.Helpers
{
    public static class HospitalHelper
    {
        /// <summary>
        ///     Builds the patient code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="hospitalCode">The hospital code.</param>
        /// <param name="ignore">if set to <c>true</c> [ignore].</param>
        /// <returns></returns>
        public static string BuildPatientCode(string code, string hospitalCode, bool include = false)
        {
            if (include)
            {
                var hospitalCodeFormat = string.Format("{0}.", hospitalCode);
                var isSetPrefix = code.Contains(hospitalCodeFormat);
                if (!isSetPrefix) code = hospitalCodeFormat + code;
            }

            return code;
        }
    }
}