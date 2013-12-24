using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class AccountSettingsEntity
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "high_quality")]
        public bool HighQuality { get; set; }

        [DataMember(Name = "public_images")]
        public bool PublicImages { get; set; }

        [DataMember(Name = "album_privacy")]
        public string AlbumPrivacy { get; set; }

        [DataMember(Name = "pro_expiration")]
        public string ProExpiration { get; set; }

        [DataMember(Name = "accepted_gallery_terms")]
        public bool AcceptedGalleryTerms { get; set; }

        [DataMember(Name = "active_emails")]
        public string[] Emails { get; set; }

        [DataMember(Name = "messaging_enabled")]
        public bool MessagingEnabled { get; set; }

        [DataMember(Name = "blocked_users")]
        public BlockedUser[] BlockedUsers { get; set; }

        public class BlockedUser
        {
            [DataMember(Name = "blocked_id")]
            public string BlockedId { get; set; }

            [DataMember(Name = "blocked_url")]
            public string BlockedUrl { get; set; }
        }
    }
}
