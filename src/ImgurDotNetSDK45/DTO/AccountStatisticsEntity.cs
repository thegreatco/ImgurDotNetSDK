using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class AccountStatisticsEntity
    {
        [DataMember(Name = "total_images")]
        public long TotalImages { get; set; }

        [DataMember(Name = "total_albums")]
        public long TotalAlbums { get; set; }

        [DataMember(Name = "disk_used")]
        public string DiskUsed { get; set; }

        [DataMember(Name = "bandwidth_used")]
        public string BandwidthUsed { get; set; }

        [DataMember(Name = "top_images")]
        public ImageEntity[] TopImages { get; set; }

        [DataMember(Name = "top_albums")]
        public GalleryEntity[] TopAlbums { get; set; }

        [DataMember(Name = "top_gallery_comments")]
        public CommentEntity[] TopGalleryComments { get; set; }
    }
}
