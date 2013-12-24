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

        public static string Join(this string[] strings, string delimeter)
        {
            return string.Join(delimeter, strings);
        }

        public static string ValidatedJoin(this string[] strings, string delimeter)
        {
            return string.Join(delimeter, strings.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        public static bool IsLower(this string @string)
        {
            var val = (int) @string[0];
            return val >= 97 && val <= 122;
        }

        public static bool IsUpper(this string @string)
        {
            var val = (int) @string[0];
            return val >= 65 && val <= 90;
        }
    }
}
