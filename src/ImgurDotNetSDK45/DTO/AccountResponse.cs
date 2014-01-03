using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    public class AccountResponse : BasicResponse
    {
        [DataMember(Name = "data")]
        public AccountResponseEntity Entity { get; set; }
    }
}
