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
    }
}
