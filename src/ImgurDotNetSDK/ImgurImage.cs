using System;
using System.Drawing;
using System.IO;

namespace ImgurDotNetSDK
{
    public class ImgurImage
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Timestamp { get; set; }

        public string Type { get; set; }

        public bool Animated { get; set; }

        public long Width { get; set; }

        public long Height { get; set; }

        public long Size { get; set; }

        public long Views { get; set; }

        public long Bandwidth { get; set; }

        public string Link { get; set; }

        public byte[] RawImage { get; set; }

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
