using System;

namespace ImgurDotNetSDK
{
    public class ImgurComment
    {
        /// <summary>
        /// Gets or sets the ID for the comment.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the image that the comment is for.
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// Gets or sets if this is a reply, this will be the value of the comment_id for the caption this a reply for.
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// Gets or sets the comment itself.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the Username of the author of the comment.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the account ID for the author.
        /// </summary>
        public long AuthorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this comment was done to an album.
        /// </summary>
        public bool OnAlbum { get; set; }

        /// <summary>
        /// Gets or sets the ID of the album cover image, this is what should be displayed for album comments.
        /// </summary>
        public string AlbumCover { get; set; }

        /// <summary>
        /// Gets or sets the number of upvotes for the comment.
        /// </summary>
        public long Upvotes { get; set; }

        /// <summary>
        /// Gets or sets the number of downvotes for the comment.
        /// </summary>
        public long Downvotes { get; set; }

        /// <summary>
        /// Gets or sets the number of upvotes minus the downvotes.
        /// </summary>
        public double Points { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of creation, epoch time
        /// </summary>
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this caption has been deleted.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets an array of all of the replies for this comment. If there are no replies to the comment then this is an empty set.
        /// </summary>
        public ImgurComment[] Children { get; set; }
    }
}
