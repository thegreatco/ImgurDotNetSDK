using System;
using System.Runtime.Serialization;

namespace ImgurDotNetSDK.DTO
{
    [DataContract]
    public class AccountResponse
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "bio")]
        public string Bio { get; set; }

        [DataMember(Name = "reputation")]
        public double Reputation { get; set; }

        [DataMember(Name = "created")]
        public long Created { get; set; }

        [DataMember(Name = "pro_expiration")]
        public string ProExpiration { get; set; }
    }
}
