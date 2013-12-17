using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class ImageEntity
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "datetime")]
        public string Timestamp { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "animated")]
        public bool Animated { get; set; }

        [DataMember(Name = "width")]
        public long Width { get; set; }

        [DataMember(Name = "height")]
        public long Height { get; set; }

        [DataMember(Name = "size")]
        public long Size { get; set; }

        [DataMember(Name = "views")]
        public long Views { get; set; }

        [DataMember(Name = "bandwidth")]
        public long Bandwidth { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }
    }
}
