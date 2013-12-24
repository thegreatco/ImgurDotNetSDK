using System;

namespace ImgurDotNetSDK
{
    public class ImgurSettings
    {
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }

        public ImgurSettings(string clientId, string clientSecret)
        {
            if (string.IsNullOrWhiteSpace(clientId)) throw new ArgumentNullException("clientId", "ClientId cannot be null or empty.");
            if (string.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentNullException("clientSecret", "ClientSecret cannot be null or empty.");
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}
