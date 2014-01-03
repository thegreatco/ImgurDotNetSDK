using System;

namespace ImgurDotNetSDK
{
    public class RetryException : Exception
    {
        public RetryException(string message)
            : base(message)
        {
        }

        public RetryException() 
            : this("Retry count exceeded.")
        {
        }
    }
}
