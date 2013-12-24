using System;
using System.Reflection;
using JetBrains.Annotations;

namespace ImgurDotNetSDK.Extensions
{
    public static class UriExtensions
    {
        [StringFormatMethod("format")]
        public static Uri ToUri(this string @string, params object[] args)
        {
            return new UriBuilder(@string.With(args)).Uri;
        }

        public static Uri FormatForUri<T>(this T obj, string baseString)
        {
            var allNull = true;
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var val = prop.GetValue(obj, null);
                if (val == null) continue;
                allNull = false;
                var stringArray = val as string[];
                if (stringArray != null)
                {
                    if (baseString.Contains("?")) baseString += "&{0}={1}".With(prop.Name.ToLower(), stringArray.ValidatedJoin(","));
                    else baseString += "?{0}={1}".With(prop.Name.ToLower(), stringArray.ValidatedJoin(","));
                }
                else if (val is Enum)
                {
                    if (baseString.Contains("?")) baseString += "&{0}={1}".With(prop.Name.ToLower(), val.ToString().ToLower());
                    else baseString += "?{0}={1}".With(prop.Name.ToLower(), val.ToString().ToLower());
                }
                else
                {
                    if (baseString.Contains("?")) baseString += "&{0}={1}".With(prop.Name.ToLower(), val);
                    else baseString += "?{0}={1}".With(prop.Name.ToLower(), val);
                }
            }
            if (allNull) throw new ArgumentException("All the properties of the object are null.  At least one property must have a value. ");
            return baseString.ToUri();
        }
    }
}
