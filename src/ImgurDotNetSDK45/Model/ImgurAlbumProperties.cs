namespace ImgurDotNetSDK
{
    public class ImgurAlbumProperties : IUrlFormatable
    {
        /// <summary>
        /// Gets or sets an array of <see cref="ImgurImage"/> ids.
        /// </summary>
        public string[] Ids { get; set; }

        /// <summary>
        /// Gets or sets the album title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the album description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the album <see cref="ImgurPrivacy"/> setting.
        /// </summary>
        public ImgurPrivacy? Privacy { get; set; }

        /// <summary>
        /// Gets or sets the album <see cref="ImgurLayout"/> setting.
        /// </summary>
        public ImgurLayout? Layout { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ImgurImage"/> id of the cover <see cref="ImgurImage"/>.
        /// </summary>
        public string Cover { get; set; }

        /// <inheritdoc />
        public string MultiWordDelimeter()
        {
            return "_";
        }

        /// <inheritdoc />
        public bool SplitOnCamelCase()
        {
            return true;
        }
    }
}