using System.Net;

namespace ImgurDotNetSDK
{
    public class ImgurBasic
    {
        /// <summary>
        /// Gets or sets the Status of the request.
        /// </summary>
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the request was successful or not.
        /// </summary>
        public bool Success { get; set; }
    }
}
