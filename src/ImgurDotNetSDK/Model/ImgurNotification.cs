namespace ImgurDotNetSDK
{
    public class ImgurNotification
    {
        /// <summary>
        /// Gets or sets an array of <see cref="ImgurReply"/>.
        /// </summary>
        public ImgurReply[] Replies { get; set; }

        /// <summary>
        /// Gets or sets an array of <see cref="ImgurMessage"/>.
        /// </summary>
        public ImgurMessage[] Messages { get; set; }
    }
}
