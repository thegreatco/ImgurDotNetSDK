using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class GalleryEntity
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "datetime")]
        public long Timestamp { get; set; }

        [DataMember(Name = "cover")]
        public string Cover { get; set; }

        [DataMember(Name = "account_url")]
        public string AccountUrl { get; set; }

        [DataMember(Name = "privacy")]
        public string Privacy { get; set; }

        [DataMember(Name = "layout")]
        public string Layout { get; set; }

        [DataMember(Name = "views")]
        public long Views { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "ups")]
        public long Upvotes { get; set; }

        [DataMember(Name = "downs")]
        public long Downvotes { get; set; }

        [DataMember(Name = "score")]
        public long Score { get; set; }

        [DataMember(Name = "is_album")]
        public bool IsAlbum { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "animated")]
        public bool IsAnimated { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }

        [DataMember(Name = "size")]
        public long Size { get; set; }

        [DataMember(Name = "bandwidth")]
        public long Bandwidth { get; set; }

        [DataMember(Name = "deletehash")]
        public string DeleteHash { get; set; }

        [DataMember(Name = "section")]
        public string Section { get; set; }

        [DataMember(Name = "vote")]
        public string Vote { get; set; }

        [DataMember(Name = "images_count")]
        public long ImagesCount { get; set; }

        [DataMember(Name = "images")]
        public ImageEntity[] Images { get; set; }
    }
}
