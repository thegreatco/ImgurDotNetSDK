using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class MessageEntity
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "from")]
        public string From { get; set; }

        [DataMember(Name = "account_id")]
        public long AccountId { get; set; }

        [DataMember(Name = "recipient_account_id")]
        public long RecipientAccountId { get; set; }

        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "timestamp")]
        public string Timestamp { get; set; }

        [DataMember(Name = "parent_id")]
        public long ParentId { get; set; }
    }
}
