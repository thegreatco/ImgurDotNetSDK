using System;

namespace ImgurDotNetSDK
{
    public class ImgurDownException : Exception
    {
        public ImgurDownException(string message) : base(message)
        {
        }
    }
}