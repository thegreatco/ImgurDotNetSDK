using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class CommentEntity
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "image_id")]
        public string ImageId { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "author_id")]
        public long AuthorId { get; set; }

        [DataMember(Name = "on_album")]
        public bool OnAlbum { get; set; }

        [DataMember(Name = "album_cover")]
        public string AlbumCover { get; set; }

        [DataMember(Name = "ups")]
        public long Upvotes { get; set; }

        [DataMember(Name = "downs")]
        public long Downvotes { get; set; }

        [DataMember(Name = "points")]
        public double Points { get; set; }

        [DataMember(Name = "datetime")]
        public long Timestamp { get; set; }

        [DataMember(Name = "parent_id")]
        public long ParentId { get; set; }

        [DataMember(Name = "deleted")]
        public bool Deleted { get; set; }

        [DataMember(Name = "children")]
        public CommentEntity[] Children { get; set; }
    }
}
