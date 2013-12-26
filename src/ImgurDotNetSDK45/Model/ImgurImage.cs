using System;
using System.Drawing;
using System.IO;

namespace ImgurDotNetSDK
{
    public class ImgurImage
    {
        /// <summary>
        /// Gets or sets the id of the image.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the image title.
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
        public long Width { get; set; }

        /// <summary>
        /// Gets or sets the image height.
        /// </summary>
        public long Height { get; set; }

        /// <summary>
        /// Gets or sets the image size in bytes.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Gets or sets the image view count.
        /// </summary>
        public long Views { get; set; }

        /// <summary>
        /// Gets or sets the bandwidth consumed by the image in bytes.
        /// </summary>
        public long Bandwidth { get; set; }

        /// <summary>
        /// Gets or sets the direct link to the image.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the delete hash, only available to the image owner.
        /// </summary>
        public string DeleteHash { get; set; }

        /// <summary>
        /// Gets or sets the section of the image (funny, cats, adviceanimals, etc.), if categorized by the imgur backend.
        /// </summary>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the raw image data.
        /// </summary>
        public byte[] RawImage { get; set; }

        /// <summary>
        /// Gets or sets the Image as parsed directly from the <see cref="RawImage"/>.
        /// </summary>
        public Image Image
        {
            get
            {
                using (var ms = new MemoryStream(RawImage))
                    return Image.FromStream(ms);
            }
        }
    }
}
