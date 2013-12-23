using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImgurDotNetSDK.Extensions;

namespace ImgurDotNetSDK
{
    public class ImgurGallery
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
        public DateTime Timestamp { get; set; }

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
        public string Privacy { get; set; }

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
        /// Gets or sets the number of upvotes for the gallery.
        /// </summary>
        public long Upvotes { get; set; }

        /// <summary>
        /// Gets or sets the number of downvotes for the gallery.
        /// </summary>
        public long Downvotes { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        public long Score { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is an album.
        /// </summary>
        public bool IsAlbum { get; set; }

        /// <summary>
        /// Gets or sets the image mime type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the image is animated.
        /// </summary>
        public bool IsAnimated { get; set; }

        /// <summary>
        /// Gets or sets the image width.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the image height.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the image size in bytes.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets the bandwidth consumed by the image in bytes.
        /// </summary>
        public long Bandwidth { get; set; }

        /// <summary>
        /// Gets or sets the delete hash, only available to the image owner.
        /// </summary>
        public string DeleteHash { get; set; }

        /// <summary>
        /// Gets or sets the section of the image (funny, cats, adviceanimals, etc.), if categorized by the imgur backend.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the current user's vote on the album. null if not signed in or if the user hasn't voted on it.
        /// </summary>
        public string Vote { get; set; }

        /// <summary>
        /// Gets or sets the number of images in the album.
        /// </summary>
        public long ImagesCount { get; set; }

        /// <summary>
        /// Gets or sets the array of <see cref="ImgurImages"/>.
        /// </summary>
        public ImgurImage[] Images { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Uri"/> for the gallery album or gallery image.
        /// </summary>
        public Uri Url
        {
            get { return IsAlbum ? "https://api.imgur.com/3/gallery/album/{0}.json".ToUri(Id) : "https://api.imgur.com/3/gallery/image/{0}.json".ToUri(Id); }
        }
    }
}
