using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class ImageIdsResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public string[] ImageIds { get; set; }
    }
}
