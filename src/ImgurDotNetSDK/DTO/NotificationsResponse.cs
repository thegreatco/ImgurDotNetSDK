using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class NotificationsResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public NotificationEntity Entity { get; set; }
    }
}
