using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class CreateAlbumEntity
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "deletehash")]
        public string DeleteHash { get; set; }
    }
}
