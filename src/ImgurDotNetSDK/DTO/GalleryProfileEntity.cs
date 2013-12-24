using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class GalleryProfileEntity
    {
        [DataMember(Name = "total_gallery_comments")]
        public long TotalGalleryComments { get; set; }

        [DataMember(Name = "total_gallery_likes")]
        public long TotalGalleryLikes { get; set; }

        [DataMember(Name = "total_gallery_submissions")]
        public long TotalGallerySubmissions { get; set; }

        [DataMember(Name = "trophies")]
        public TrophyEntity[] Trophies { get; set; }
    }
}
