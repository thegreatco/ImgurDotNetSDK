using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class AlbumCountResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public long Count { get; set; }
    }
}
