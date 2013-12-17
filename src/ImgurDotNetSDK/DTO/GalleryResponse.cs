using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class GalleryResponse : ImgurBaseResponse
    {
        [DataMember(Name = "data")]
        public GalleryEntity[] Data { get; set; }
    }
}
