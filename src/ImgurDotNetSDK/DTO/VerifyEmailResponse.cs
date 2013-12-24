using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class VerifyEmailResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public bool Entity { get; set; }
    }
}
