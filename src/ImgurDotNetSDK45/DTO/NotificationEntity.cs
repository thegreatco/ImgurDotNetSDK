using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class NotificationEntity
    {
        [DataMember(Name = "replies")]
        public ReplyEntity[] Replies { get; set; }

        [DataMember(Name = "messages")]
        public MessageEntity[] Messages { get; set; }
    }
}
