using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurReplyContent
    {
        /// <summary>
        /// Gets or sets the <see cref="ImgurReplyContent"/> id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the image id.
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// Gets or sets the comment itself.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the name of the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the Id of the author.
        /// </summary>
        public long AuthorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reply is on an album.
        /// </summary>
        public bool OnAlbum { get; set; }

        /// <summary>
        /// Gets or sets the album cover.
        /// </summary>
        public string AlbumCover { get; set; }

        /// <summary>
        /// Gets or sets the number of upvotes.
        /// </summary>
        public long Upvotes { get; set; }

        /// <summary>
        /// Gets or sets the number of downvotes.
        /// </summary>
        public long Downvotes { get; set; }

        /// <summary>
        /// Gets or sets the number of points.
        /// </summary>
        public long Points { get; set; }

        /// <summary>
        /// Gets or sets the Timestamp.
        /// </summary>
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the parent id of the reply.
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reply has been deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the current user has upvoted the reply.
        /// </summary>
        public bool? Vote { get; set; }
    }
}
