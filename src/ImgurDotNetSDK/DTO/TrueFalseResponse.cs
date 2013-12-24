using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class TrueFalseResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public bool Response { get; set; }
    }
}
