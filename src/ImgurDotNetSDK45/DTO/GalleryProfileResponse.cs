using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class GalleryProfileResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public GalleryProfileEntity Entity { get; set; }
    }
}
