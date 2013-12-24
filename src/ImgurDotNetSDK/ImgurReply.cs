using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurReply
    {
        /// <summary>
        /// Gets or sets the <see cref="ImgurReply"/> id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the account id of the sender.
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the message has been viewed.
        /// </summary>
        public bool Viewed { get; set; }

        /// <summary>
        /// Gets or sets the content of the reply.
        /// </summary>
        public ImgurReplyContent Content { get; set; }
    }
}
