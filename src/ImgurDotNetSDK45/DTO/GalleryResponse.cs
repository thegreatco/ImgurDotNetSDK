using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class GalleryResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public GalleryEntity[] Entity { get; set; }
    }
}
