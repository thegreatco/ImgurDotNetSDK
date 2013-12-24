using System;
using System.Collections.Generic;
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
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException("accessToken", "Access Token cannot be null.");
            if (string.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentNullException("refreshToken", "Refresh Token cannot be null.");
            if (expiresIn == default(long)) throw new ArgumentException("Expiration time is invalid.");
            
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpirationDate = DateTime.UtcNow + TimeSpan.FromSeconds(expiresIn);
        }
    }
}
