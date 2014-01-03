using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace ImgurDotNetSDK
{
    public class ImgurCredentials
    {
        public string AccessToken { get; private set; }

        public string RefreshToken { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public ImgurCredentials(string accessToken, string refreshToken, long expiresIn)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(accessToken), "Access Token cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(refreshToken), "Refresh Token cannot be null or whitespace.");
            Contract.Requires<ArgumentException>(expiresIn != default(long), "Expiration time is invalid.");
            
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpirationDate = DateTime.UtcNow + TimeSpan.FromSeconds(expiresIn);
        }
    }
}
