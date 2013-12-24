using System;
using System.Linq;
using JetBrains.Annotations;

namespace ImgurDotNetSDK.Extensions
{
    public static class StringExtensions
    {
        [StringFormatMethod("format")]
        public static string With(this string @string, params object[] args)
        {
            return string.Format(@string, args);
        }

        [StringFormatMethod("format")]
        public static Uri ToUri(this string @string, params object[] args)
        {
            return new UriBuilder(@string.With(args)).Uri;
        }

        public static string Join(this string[] strings, string delimeter)
        {
            return string.Join(delimeter, strings);
        }

        public static string ValidatedJoin(this string[] strings, string delimeter)
        {
            return string.Join(delimeter, strings.Where(x => !string.IsNullOrWhiteSpace(x)));
        }
    }
}
