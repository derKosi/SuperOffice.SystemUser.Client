// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperOffice.SystemUser
{
    public static class StringExtensions
    {
        public static string FormatWith(this string formatString, params string[] parameters)
        {
            return string.Format(formatString, parameters);
        }

        public static bool IsValidSubDomain(this string subdomain)
        {
            string domain = subdomain.ToLower();

            return domain.Equals("sod", StringComparison.OrdinalIgnoreCase)
                || domain.Equals("qastage", StringComparison.OrdinalIgnoreCase)
                || domain.Equals("stage", StringComparison.OrdinalIgnoreCase)
                || domain.Equals("qaonline", StringComparison.OrdinalIgnoreCase)
                || domain.Equals("online", StringComparison.OrdinalIgnoreCase);
        }
    }
}
