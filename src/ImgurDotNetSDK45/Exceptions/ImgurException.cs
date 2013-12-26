using System;

namespace ImgurDotNetSDK
{
    public class ImgurException : Exception
    {
        public ImgurException(string message)
            : base(message)
        {
        }

        public ImgurException()
        {
        }
    }
}