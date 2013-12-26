namespace ImgurDotNetSDK
{
    public class ImgurMessage
    {
        /// <summary>
        /// Gets or sets the <see cref="ImgurMessage"/> id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the sender name.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the sender account id.
        /// </summary>
        public long AccountId { get; set; }

        /// <summary>
        /// Gets or sets the recipient account id.
        /// </summary>
        public long RecipientAccountId { get; set; }

        /// <summary>
        /// Gets or sets the subject of the message.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the timestamp the message was sent.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the parent id of the message.
        /// </summary>
        public long ParentId { get; set; }
    }
}
