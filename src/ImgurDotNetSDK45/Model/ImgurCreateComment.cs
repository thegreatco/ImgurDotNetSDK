namespace ImgurDotNetSDK
{
    public class ImgurCreateComment
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
    }
}
