using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class AccountStatisticsResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public AccountStatisticsEntity Entity { get; set; }
    }
}
