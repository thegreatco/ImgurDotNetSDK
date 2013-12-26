namespace ImgurDotNetSDK
{
    public class ImgurAccountStatistics
    {
        /// <summary>
        /// Gets or sets the amount of images associated with the account.
        /// </summary>
        public long TotalImages { get; set; }

        /// <summary>
        /// Gets or sets the amount of albums associated with the account.
        /// </summary>
        public long TotalAlbums { get; set; }

        /// <summary>
        /// Gets or sets the amount of disk space used by the images.
        /// </summary>
        public string DiskUsed { get; set; }

        /// <summary>
        /// Gets or sets the amount of bandwidth used by the account.
        /// </summary>
        public string BandwidthUsed { get; set; }

        /// <summary>
        /// Gets or sets the most popular Images in the account.
        /// </summary>
        public ImgurImage[] TopImages { get; set; }

        /// <summary>
        /// Gets or sets the most popular albums in the account.
        /// </summary>
        public ImgurGallery[] TopAlbums { get; set; }

        /// <summary>
        /// Gets or sets the most popular gallery comments created by the user.
        /// </summary>
        public ImgurComment[] TopGalleryComments { get; set; }
    }
}
