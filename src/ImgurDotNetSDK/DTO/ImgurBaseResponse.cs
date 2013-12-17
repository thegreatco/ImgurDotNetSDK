using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class ImgurBaseResponse
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "status")]
        public int Status { get; set; }
    }
}
