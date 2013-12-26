using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurReplyComment
    {
        /// <summary>
        /// Gets or sets the actual comment.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the ID of the image that the comment is for.
        /// </summary>
        public string ImageId { get; set; }
    }
}
