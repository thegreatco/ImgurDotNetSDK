using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class TrophyEntity
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "name_clean")]
        public string NameClean { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "data")]
        public string Data { get; set; }

        [DataMember(Name = "data_link")]
        public string DataLink { get; set; }

        [DataMember(Name = "datetime")]
        public long Timestamp { get; set; }
    }
}
