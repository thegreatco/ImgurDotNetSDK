using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class CreateAlbumResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public CreateAlbumEntity Entity { get; set; }
    }
}
