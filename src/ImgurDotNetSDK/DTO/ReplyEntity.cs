using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class ReplyEntity
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "account_id")]
        public long AccountId { get; set; }

        [DataMember(Name = "viewed")]
        public bool Viewed { get; set; }

        [DataMember(Name = "content")]
        public ReplyEntityContent Content { get; set; }
    }
}
