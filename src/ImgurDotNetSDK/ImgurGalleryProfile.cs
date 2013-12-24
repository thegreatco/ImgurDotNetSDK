using System;

namespace ImgurDotNetSDK
{
    public class ImgurGalleryProfile
    {
        /// <summary>
        /// Gets or sets the total number of comments the user has made in the gallery.
        /// </summary>
        public long TotalGalleryComments { get; set; }

        /// <summary>
        /// Gets or sets the total number of images liked by the user in the gallery.
        /// </summary>
        public long TotalGalleryLikes { get; set; }

        /// <summary>
        /// Gets or sets the total number of images submitted by the user.
        /// </summary>
        public long TotalGallerySubmissions { get; set; }

        /// <summary>
        /// Gets or sets the array of trophies that the user has.
        /// </summary>
        public ImgurTrophy[] Trophies { get; set; }
    }
}
