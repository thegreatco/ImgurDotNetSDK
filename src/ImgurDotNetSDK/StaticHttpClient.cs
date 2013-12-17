using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net;

namespace ImgurDotNet
{
    internal class StaticHttpClient
    {
        public static HttpClient Client { get; private set; }
        
        static StaticHttpClient()
        {
            Client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
                    {
                        Timeout = TimeSpan.FromSeconds(60)
                    };
        }
    }
}
