// SuperOffice AS licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperOffice.SystemUser.Client.Exceptions
{
    /// <summary>
    /// The exception that is thrown whenever the wrong SuperOffice CRM online subdomain is specified.
    /// </summary>
    public class InvalidSubDomainException : Exception
    {
        /// <summary>
        /// Message
        /// </summary>
        /// <param name="message">Reason for the exception.</param>
        public InvalidSubDomainException(string message) : base(message)
        {
        }

        /// <summary>
        /// Exception Wrapper
        /// </summary>
        /// <param name="message">Reason for the exception.</param>
        /// <param name="innerException">The real problem for the exception.</param>
        public InvalidSubDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
