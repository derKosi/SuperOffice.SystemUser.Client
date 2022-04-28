// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperOffice.SystemUser.Helpers
{
    /// <summary>
    /// Useful for getting formatted URL strings.
    /// </summary>
    public class UrlHelper
    {
        private readonly string _subdomain;

        /// <summary>
        /// Helper class for getting common URL strings for an environment.
        /// </summary>
        /// <param name="subdomain">Online environment subdomain (sod, qastage, online)</param>
        public UrlHelper(string subdomain)
        {
            _subdomain = subdomain;
        }

        internal string GetClaimsIssuer()
        {
            return Constants.OAuth.ClaimsIssuer.FormatWith(_subdomain);
        }

        internal string GetMetadataAddress()
        {
            return Constants.OAuth.MetadataEndpoint.FormatWith(_subdomain);
        }

        internal string GetAuthority()
        {
            return Constants.OAuth.Authority.FormatWith(_subdomain);
        }
    }
}
