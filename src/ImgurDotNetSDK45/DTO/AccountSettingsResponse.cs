using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    internal class AccountSettingsResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public AccountSettingsEntity Entity { get; set; }
    }
}
