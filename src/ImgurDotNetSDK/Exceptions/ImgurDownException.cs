using System;

namespace ImgurDotNetSDK
{
    public class ImgurDownException : ImgurException
    {
        public ImgurDownException(string message)
            : base(message)
        {
        }
    }
}