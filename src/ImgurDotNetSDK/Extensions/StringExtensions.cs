using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK.Extensions
{
    public static class StringExtensions
    {
        public static string EnumToString(this GalleryType val)
        {
            return val.ToString().ToLower();
        }

        public static string EnumToString(this SortType val)
        {
            return val.ToString().ToLower();
        }

        public static string With(this string @string, params object[] args)
        {
            return string.Format(@string, args);
        }

        public static Uri ToUri(this string @string, params object[] args)
        {
            return new UriBuilder(@string.With(args)).Uri;
        }
    }
}
