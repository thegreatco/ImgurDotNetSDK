using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class ImagesResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public List<ImageEntity> Data { get; set; }
    }
}
