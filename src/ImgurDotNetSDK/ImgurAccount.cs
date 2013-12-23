using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurAccount
    {
        /// <summary>
        /// Gets or sets the account id for the username requested.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the account username, will be the same as requested in the URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a basic description the user has filled out.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// Gets or sets the reputation fro the account, in it's numerical format.
        /// </summary>
        public double Reputation { get; set; }

        /// <summary>
        /// Gets or sets the epoch time of account creation.
        /// </summary>
        public long Created { get; set; }

        /// <summary>
        /// Gets or sets the expiration time if the account is a pro user, null otherwise.
        /// </summary>
        public DateTime? ProExpiration { get; set; }
    }
}
