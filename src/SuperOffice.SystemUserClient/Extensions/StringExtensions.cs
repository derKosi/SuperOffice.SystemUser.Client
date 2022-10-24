// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperOffice.SystemUser
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method to simplify working with formatted strings.
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string FormatWith(this string formatString, params string[] parameters)
        {
            return string.Format(formatString, parameters);
        }

        /// <summary>
        /// Extension method to validate a SuperOffice CRM Online sub-domain.
        /// </summary>
        /// <param name="subdomain"></param>
        /// <returns></returns>
        public static bool IsValidSubDomain(this string subdomain)
        {
            string domain = subdomain.ToLower();

            return domain.StartsWith("sod", StringComparison.OrdinalIgnoreCase)
                || domain.StartsWith("qaonline", StringComparison.OrdinalIgnoreCase)
                || domain.StartsWith("stage", StringComparison.OrdinalIgnoreCase)
                || domain.StartsWith("online", StringComparison.OrdinalIgnoreCase);
        }
    }
}
