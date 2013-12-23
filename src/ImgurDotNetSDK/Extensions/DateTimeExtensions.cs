using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FromUnixTime(this long val)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(val);
        }
    }
}
