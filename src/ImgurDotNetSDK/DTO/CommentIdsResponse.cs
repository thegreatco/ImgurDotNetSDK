using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class CommentIdsResponse
    {
        [DataMember(Name = "data")]
        public string[] CommentIds { get; set; }
    }
}
