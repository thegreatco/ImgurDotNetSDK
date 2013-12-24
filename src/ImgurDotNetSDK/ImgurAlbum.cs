using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurAlbum
    {
        /// <summary>
        /// Gets or sets the id of the image.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the gallery title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the image description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the timestamp the image was created.
        /// </summary>
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the cover image for the gallery.
        /// </summary>
        public string Cover { get; set; }

        /// <summary>
        /// Gets or sets the url of the account that created the gallery.
        /// </summary>
        public string AccountUrl { get; set; }

        /// <summary>
        /// Gets or sets the privacy level of the album, you can only view public if not logged in as album owner.
        /// </summary>
        public ImgurPrivacy Privacy { get; set; }

        /// <summary>
        /// Gets or sets the view layout of the album.
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the image view count.
        /// </summary>
        public long Views { get; set; }

        /// <summary>
        /// Gets or sets the direct link to the image.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the delete hash, only available to the image owner.
        /// </summary>
        public string DeleteHash { get; set; }

        /// <summary>
        /// Gets or sets the number of images in the album.
        /// </summary>
        public long ImagesCount { get; set; }

        /// <summary>
        /// Gets or sets the array of <see cref="ImgurImage"/>.
        /// </summary>
        public ImgurImage[] Images { get; set; }
    }
}
