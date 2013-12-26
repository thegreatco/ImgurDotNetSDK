using System;

namespace ImgurDotNetSDK
{
    public class UnauthorizedException : ImgurException
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }

        public UnauthorizedException()
        {
        }
    }
}