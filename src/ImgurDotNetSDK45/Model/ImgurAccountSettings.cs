using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurAccountSettings : IUrlFormatable
    {
        /// <summary>
        /// Gets or sets the user email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can upload high quality images.
        /// </summary>
        public bool? HighQuality { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether all images are publically accessible.
        /// </summary>
        public bool? PublicImages { get; set; }

        /// <summary>
        /// Gets or sets the default album privacy settings.
        /// </summary>
        public ImgurPrivacy? AlbumPrivacy { get; set; }

        /// <summary>
        /// Gets or sets the expiration time if the account is a pro user, null otherwise.
        /// </summary>
        public DateTime? ProExpiration { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the gallery terms were accepted.
        /// </summary>
        public bool? AcceptedGalleryTerms { get; set; }

        /// <summary>
        /// Gets or sets the array of email addresses.
        /// </summary>
        public string[] Emails { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether messaging is enabled.
        /// </summary>
        public bool? MessagingEnabled { get; set; }

        /// <summary>
        /// Gets or sets the array of blocked users.
        /// </summary>
        public BlockedUser[] BlockedUsers { get; set; }

        /// <summary>
        /// Gets or sets the biography of the user.
        /// </summary>
        public string Biography { get; set; }

        public class BlockedUser
        {
            /// <summary>
            /// Gets or sets the Id of the blocked user.
            /// </summary>
            public string BlockedId { get; set; }

            /// <summary>
            /// Gets or sets the Url of the blocked user.
            /// </summary>
            public string BlockedUrl { get; set; }
        }

        /// <inheritdoc />
        public string MultiWordDelimeter()
        {
            return "_";
        }

        /// <inheritdoc />
        public bool SplitOnCamelCase()
        {
            return true;
        }
    }
}
