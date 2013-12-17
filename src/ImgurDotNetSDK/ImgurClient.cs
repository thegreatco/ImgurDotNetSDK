using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using AutoMapper;
using ImgurDotNet;
using ImgurDotNetSDK;
using ImgurDotNetSDK.DTO;
using ImgurDotNetSDK.Extensions;
using ServiceStack.Text;

namespace ImgurDotNetSDK
{
    public class ImgurClient
    {
        private const string TokenRequestUrl = "https://api.imgur.com/oauth2/token";
        private const string UploadUrl = "https://api.imgur.com/3/upload.json";
        private const string StatsUrl = "https://api.imgur.com/3/stats.json?view={0}";
        internal const string AlbumUrl = "https://api.imgur.com/3/album/{0}.json";
        private const string ImageUrl = "https://api.imgur.com/3/image/{0}.json";
        private const string DeleteUrl = "https://api.imgur.com/3/delete/{0}.json";
        
        /// <summary>
        /// {0} - GalleryType enum
        /// {1} - SortType enum
        /// {2} - Page number
        /// {3} - Show viral images from user submitted.
        /// </summary>
        private const string GalleryUrl = "https://api.imgur.com/3/gallery/{0}/{1}/{2}.json?showViral={3}";

        private readonly ImgurSettings _settings;

        private ImgurCredentials _credentials;

        /// <summary>
        /// Creates a new instance of <see cref="ImgurClient"/> with the supplied settings.
        /// </summary>
        /// <param name="settings"> The <see cref="ImgurSettings"/> to use for the new client. </param>
        public ImgurClient(ImgurSettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings", "Settings cannot be null.");
            _settings = settings;

            Mapper.CreateMap<ImageEntity, ImgurImage>();
            Mapper.CreateMap<GalleryEntity, ImgurGallery>();
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImgurClient"/> with the supplied settings.
        /// </summary>
        /// <param name="settings"> The <see cref="ImgurSettings"/> to use for the new client. </param>
        /// <param name="credentials"> The <see cref="ImgurCredentials"/> to use for the user if they have already been obtained. </param>
        public ImgurClient(ImgurSettings settings, ImgurCredentials credentials) : this(settings)
        {
            _credentials = credentials;
        }

        /// <summary>
        /// The user needs to be sent to this Url which will give them a pin once they log in, the pin needs to be fed into the Login method.
        /// </summary>
        public string LoginUrl
        {
            get
            {
                return string.Format("https://api.imgur.com/oauth2/authorize?client_id={0}&response_type=pin&state=null", _settings.ClientId);
            }
        }

        /// <summary>
        /// Takes the pin provided by the user and uses it to get an OAuth Access Token and Refresh Token.
        /// </summary>
        /// <param name="pin"> The pin provided by imgur during the authentication process on the imgur website. </param>
        /// <returns> A task for asynchronous waiting. </returns>
        public async Task Login(string pin)
        {
            var postContent = new FormUrlEncodedContent(new[]
                                                            {
                                                                new KeyValuePair<string, string>("client_id", _settings.ClientId),
                                                                new KeyValuePair<string, string>("client_secret", _settings.ClientSecret),
                                                                new KeyValuePair<string, string>("grant_type", "pin"),
                                                                new KeyValuePair<string, string>("pin", pin)
                                                            });
            var response = await Get<LoginResponse>(TokenRequestUrl, postContent);
            if (response == null) throw new Exception("Login Failed.");
            _credentials = new ImgurCredentials(response.AccessToken, response.RefreshToken, response.ExpiresIn);
        }

        /// <summary>
        /// Takes the existing Refresh Token and exchanges it for an updated Access Token.
        /// </summary>
        /// <returns> A task for asynchronous waiting. </returns>
        public async Task RefreshLogin()
        {
            if (string.IsNullOrWhiteSpace(_credentials.RefreshToken)) throw new ArgumentException("Refresh Token cannot be null.");
            var postContent = new FormUrlEncodedContent(new[]
                                                            {
                                                                new KeyValuePair<string, string>("refresh_token", _credentials.RefreshToken),
                                                                new KeyValuePair<string, string>("client_id", _settings.ClientId),
                                                                new KeyValuePair<string, string>("client_secret", _settings.ClientSecret),
                                                                new KeyValuePair<string, string>("grant_type", "refresh_token")
                                                            });
            var response = await Get<LoginResponse>(TokenRequestUrl, postContent);
            if (response == null) throw new Exception("Login Failed.");
            _credentials = new ImgurCredentials(response.AccessToken, response.RefreshToken, response.ExpiresIn);
        }

        /// <summary>
        /// Gets the Main Gallery page, eg imgur.com
        /// </summary>
        /// <param name="galleryType"> The <see cref="GalleryType"/> to retrieve. </param>
        /// <param name="sortType"> The <see cref="SortType"/> to use. </param>
        /// <param name="page"> The page number to retrieve. </param>
        /// <param name="showViral"> Show viral images or not. </param>
        /// <returns></returns>
        public async Task<IEnumerable<ImgurGallery>> GetMainGallery(GalleryType galleryType, SortType sortType, int page = 0, bool showViral = false)
        {
            var dtoGallery = await Get<GalleryResponse>(GalleryUrl.With(galleryType.EnumToString(), sortType.EnumToString(), page, showViral));
            return dtoGallery.Data.Select(Mapper.Map<GalleryEntity, ImgurGallery>);
        }

        /// <summary>
        /// Get a gallery based on an <see cref="ImgurGallery"/> returned by a gallery listing page, like the homepage.
        /// </summary>
        /// <param name="gallery"> The <see cref="ImgurGallery"/> to retrieve. </param>
        /// <returns> The full gallery from Imgur. </returns>
        public async Task<ImgurGallery> GetGallery(ImgurGallery gallery)
        {
            return await GetGallery(gallery.Url);
        }

        /// <summary>
        /// Get a gallery base on a <see cref="Uri"/>.
        /// </summary>
        /// <param name="galleryUrl"> The <see cref="Uri"/> of the <see cref="ImgurGallery"/> to retrieve. </param>
        /// <returns> The full gallery from Imgur.</returns>
        public async Task<ImgurGallery> GetGallery(Uri galleryUrl)
        {
            var dtoGallery = await Get<GalleryResponse>(galleryUrl);
            return dtoGallery.Data.Select(Mapper.Map<GalleryEntity, ImgurGallery>).First();
        }

        private static string EscapeBase64(string str)
        {
            var escaped = string.Empty;
            for (var i = 0; i < str.Length; i ++)
            {
                escaped += Uri.EscapeDataString(str.Substring(i, 1));
            }

            return escaped;
        }

        private async Task<T> Get<T>(string request, HttpContent postData = null) where T : class
        {
            return await Get<T>(new UriBuilder(request).Uri, postData);
        }

        private async Task<T> Get<T>(Uri requestUri, HttpContent postData = null, int retryCount = 0) where T : class
        {
            if (retryCount > 5) throw new Exception("Retry count exceeded.");

            var httpMethod = postData == null ? HttpMethod.Get : HttpMethod.Post;
            using (var request = new HttpRequestMessage(httpMethod, requestUri) {Content = postData})
            {
                if (_credentials != null)
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + _credentials.AccessToken);
                using (var response = await StaticHttpClient.Client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                        return JsonSerializer.DeserializeFromStream<T>(await response.Content.ReadAsStreamAsync());
                    var statusCode = response.StatusCode;
                    switch (statusCode)
                    {
                        case HttpStatusCode.Forbidden:
                            await RefreshLogin();
                            return await Get<T>(requestUri, postData, retryCount + 1);
                        case HttpStatusCode.MethodNotAllowed:
                        case HttpStatusCode.BadGateway:
                            throw new ImgurDownException("Imgur is down, try the request again later.");
                        default:
                            throw new Exception("Unexpected HttpStatusCode encountered.");
                    }
                }
            }
        }
    }
}
