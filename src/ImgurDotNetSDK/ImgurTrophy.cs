using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurTrophy
    {
        /// <summary>
        /// Gets or sets the ID of the trophy, this is unique to each trophy.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the trophy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID of a trophy type.
        /// </summary>
        public string NameClean { get; set; }

        /// <summary>
        /// Gets or sets a description of the trophy and how it was earned.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the image or the ID of the comment where the trophy was earned.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets a link to where the trophy was earned.
        /// </summary>
        public string DataLink { get; set; }

        /// <summary>
        /// Gets or sets the date the trophy was earned.
        /// </summary>
        public DateTime? Timestamp { get; set; }
    }
}
