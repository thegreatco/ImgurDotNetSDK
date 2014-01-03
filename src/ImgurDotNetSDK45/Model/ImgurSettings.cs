using System;
using System.Diagnostics.Contracts;

namespace ImgurDotNetSDK
{
    public class ImgurSettings
    {
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }

        public ImgurSettings(string clientId, string clientSecret)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(clientId), "Client Id cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(clientSecret), "Client Secret cannot be null or whitespace.");
            
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}
