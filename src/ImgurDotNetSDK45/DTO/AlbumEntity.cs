using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class AlbumEntity
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

        [DataMember(Name = "deletehash")]
        public string DeleteHash { get; set; }

        [DataMember(Name = "images_count")]
        public long ImagesCount { get; set; }

        [DataMember(Name = "images")]
        public ImageEntity[] Images { get; set; }
    }
}
