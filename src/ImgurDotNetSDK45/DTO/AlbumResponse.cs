﻿using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class AlbumResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public AlbumEntity Entity { get; set; }
    }
}
