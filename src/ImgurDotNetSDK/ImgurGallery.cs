using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImgurDotNetSDK.Extensions;

namespace ImgurDotNetSDK
{
    public class ImgurGallery
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Timestamp { get; set; }

        public string Cover { get; set; }

        public string AccountUrl { get; set; }

        public string Privacy { get; set; }

        public string Layout { get; set; }

        public long Views { get; set; }

        public string Link { get; set; }

        public long Upvotes { get; set; }

        public long Downvotes { get; set; }

        public long Score { get; set; }

        public bool IsAlbum { get; set; }

        public string Vote { get; set; }

        public long ImagesCount { get; set; }

        public ImgurImage[] Images { get; set; }

        public Uri Url
        {
            get { return IsAlbum ? new UriBuilder(ImgurClient.AlbumUrl.With(Id)).Uri : null; }
        }
    }
}
