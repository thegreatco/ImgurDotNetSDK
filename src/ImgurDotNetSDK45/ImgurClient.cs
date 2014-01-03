using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ImgurDotNet;
using ServiceStack.Text;

namespace ImgurDotNetSDK
{
    public partial class ImgurClient
    {
        private const string TokenRequestUrl = "https://api.imgur.com/oauth2/token";
        
        /// <summary>
        /// {0} - GalleryType enum
        /// {1} - SortType enum
        /// {2} - Page number
        /// {3} - Show viral images from user submitted.
        /// </summary>
        private const string GalleryUrl = "https://api.imgur.com/3/gallery/{0}/{1}/{2}.json?showViral={3}";

        private readonly ImgurSettings _settings;

        public ImgurCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the client is being debugged.
        /// This should be used when actual requests to the Imgur API should be completed using the <see cref="DebugResponse"/> code.
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// Gets or sets the HttpStatus that should be returned by Imgur.
        /// </summary>
        public int DebugResponse { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="ImgurClient"/> with the supplied settings.
        /// </summary>
        /// <param name="settings"> The <see cref="ImgurSettings"/> to use for the new client. </param>
        public ImgurClient(ImgurSettings settings)
        {
            Contract.Requires<ArgumentNullException>(settings != null, "Settings cannot be null.");
            _settings = settings;

            Mapper.CreateMap<DTO.MessageEntity, ImgurMessage>();
            Mapper.CreateMap<DTO.ReplyEntityContent, ImgurReplyContent>()
                .ForMember(x => x.Timestamp, y => y.ResolveUsing(x => x.Timestamp.FromUnixTime()));
            Mapper.CreateMap<DTO.ReplyEntity, ImgurReply>();
            Mapper.CreateMap<DTO.NotificationEntity, ImgurNotification>();
            Mapper.CreateMap<DTO.AccountSettingsEntity, ImgurAccountSettings>()
                .ForMember(x => x.ProExpiration, y => y.ResolveUsing(x =>
                                                                     {
                                                                         if (x.ProExpiration == "false") return null;
                                                                         return long.Parse(x.ProExpiration).FromUnixTime();
                                                                     }));
            Mapper.CreateMap<DTO.CommentEntity, ImgurComment>()
                .ForMember(x => x.Timestamp, y => y.ResolveUsing(x => x.Timestamp.FromUnixTime()));
            Mapper.CreateMap<DTO.TrophyEntity, ImgurTrophy>()
                .ForMember(x => x.Timestamp, y => y.ResolveUsing(x => x.Timestamp.FromUnixTime()));
            Mapper.CreateMap<DTO.GalleryProfileEntity, ImgurGalleryProfile>();
            Mapper.CreateMap<DTO.AccountStatisticsEntity, ImgurAccountStatistics>();
            Mapper.CreateMap<DTO.ImageEntity, ImgurImage>()
                .ForMember(x => x.Timestamp, y => y.ResolveUsing(x => x.Timestamp.FromUnixTime()));
            Mapper.CreateMap<DTO.GalleryEntity, ImgurGallery>()
                .ForMember(x => x.Timestamp, y => y.ResolveUsing(x => x.Timestamp.FromUnixTime()));
            Mapper.CreateMap<DTO.AccountResponseEntity, ImgurAccount>()
                .ForMember(x => x.Created, y => y.ResolveUsing(x => x.Created.FromUnixTime()))
                .ForMember(x => x.ProExpiration, y => y.ResolveUsing(x =>
                                                                     {
                                                                         if (string.IsNullOrWhiteSpace(x.ProExpiration) || x.ProExpiration == "false") return null;
                                                                         return long.Parse(x.ProExpiration).FromUnixTime();
                                                                     }));
            Mapper.CreateMap<DTO.BasicResponse, ImgurBasic>()
                .ForMember(x => x.Status, y => y.ResolveUsing(x => (HttpStatusCode) x.Status));
        }

        /// <summary>
        /// Creates a new instance of <see cref="ImgurClient"/> with the supplied settings.
        /// </summary>
        /// <param name="settings"> The <see cref="ImgurSettings"/> to use for the new client. </param>
        /// <param name="credentials"> The <see cref="ImgurCredentials"/> to use for the user if they have already been obtained. </param>
        public ImgurClient(ImgurSettings settings, ImgurCredentials credentials) : this(settings)
        {
            Contract.Requires<ArgumentNullException>(credentials != null, "Credentials cannot be null.");

            Credentials = credentials;
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
            var response = await Get<DTO.LoginResponse>(TokenRequestUrl, HttpMethod.Post, postContent);
            if (response == null) throw new Exception("Login Failed.");
            Credentials = new ImgurCredentials(response.AccessToken, response.RefreshToken, response.ExpiresIn);
        }

        /// <summary>
        /// Takes the existing Refresh Token and exchanges it for an updated Access Token.
        /// </summary>
        /// <returns> A task for asynchronous waiting. </returns>
        public async Task RefreshLogin()
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(Credentials.RefreshToken), "Refresh Token cannot be null.");
            
            var postContent = new FormUrlEncodedContent(new[]
                                                            {
                                                                new KeyValuePair<string, string>("refresh_token", Credentials.RefreshToken),
                                                                new KeyValuePair<string, string>("client_id", _settings.ClientId),
                                                                new KeyValuePair<string, string>("client_secret", _settings.ClientSecret),
                                                                new KeyValuePair<string, string>("grant_type", "refresh_token")
                                                            });
            var response = await Get<DTO.LoginResponse>(TokenRequestUrl, HttpMethod.Post, postContent);
            if (response == null) throw new Exception("Login Failed.");
            Credentials = new ImgurCredentials(response.AccessToken, response.RefreshToken, response.ExpiresIn);
        }

        /// <summary>
        /// Gets the Main Gallery page, eg imgur.com
        /// </summary>
        /// <param name="galleryType"> The <see cref="ImgurGalleryType"/> to retrieve. </param>
        /// <param name="sortType"> The <see cref="SortType"/> to use. </param>
        /// <param name="page"> The page number to retrieve. </param>
        /// <param name="showViral"> Show viral images or not. </param>
        /// <returns></returns>
        public async Task<IEnumerable<ImgurGallery>> GetMainGallery(ImgurGalleryType galleryType, SortType sortType, int page = 0, bool showViral = false)
        {
            var dtoGallery = await Get<DTO.GalleryResponse>(GalleryUrl.With(galleryType.EnumToString(), sortType.EnumToString(), page, showViral), HttpMethod.Get);
            return dtoGallery.Entity.Select(Mapper.Map<DTO.GalleryEntity, ImgurGallery>);
        }

        /// <summary>
        /// Get a gallery based on an <see cref="ImgurGallery"/> returned by a gallery listing page, like the homepage.
        /// </summary>
        /// <param name="gallery"> The <see cref="ImgurGallery"/> to retrieve. </param>
        /// <param name="autodownload"> Autodownload images for the gallery, if set to false, a subsequent call to GetImage will need to be made. </param>
        /// <returns> The full gallery from Imgur. </returns>
        public async Task<ImgurGallery> GetGallery(ImgurGallery gallery, bool autodownload = true)
        {
            return await GetGallery(gallery.Url, autodownload);
        }

        /// <summary>
        /// Get a gallery base on a <see cref="Uri"/>.
        /// </summary>
        /// <param name="galleryUrl"> The <see cref="Uri"/> of the <see cref="ImgurGallery"/> to retrieve. </param>
        /// <param name="autodownload"> Autodownload images for the gallery, if set to false, a subsequent call to GetImage will need to be made. </param>
        /// <returns> The full gallery from Imgur.</returns>
        public async Task<ImgurGallery> GetGallery(Uri galleryUrl, bool autodownload = true)
        {
            var dtoGallery = await Get<DTO.GalleryResponse>(galleryUrl, HttpMethod.Get);
            var gallery = dtoGallery.Entity.Select(Mapper.Map<DTO.GalleryEntity, ImgurGallery>).First();
            if (autodownload)
                foreach (var image in gallery.Images)
                    image.RawImage = await GetImage(image.Link);
            
            return gallery;
        }

        /// <summary>
        /// Download the image associated with the <see cref="ImgurImage"/>.
        /// </summary>
        /// <param name="image"> The <see cref="ImgurImage"/> object for which to download the image. </param>
        /// <returns> The <see cref="ImgurImage"/> with the full image data. </returns>
        public async Task<ImgurImage> GetImage(ImgurImage image)
        {
            image.RawImage = await GetImage(image.Link);
            return image;
        }

        public async Task<ImgurImage> GetImage(ImgurGallery gallery)
        {
            if (gallery.IsAlbum) return null;

            var image = new ImgurImage { Id = gallery.Id, Timestamp = gallery.Timestamp, RawImage = await GetImage(gallery.Link) };

            return image;
        }

        private async Task<T> Get<T>(string requestUrl, HttpMethod httpMethod, HttpContent postData = null) where T : class
        {
            return await Get<T>(new UriBuilder(requestUrl).Uri, httpMethod, postData);
        }

        private async Task<T> Get<T>(Uri requestUri, HttpMethod httpMethod, HttpContent postData = null, int retryCount = 0) where T : class
        {
            Contract.Requires<ArgumentNullException>(requestUri != null);
            Contract.Requires<ArgumentNullException>(httpMethod != null);
            Contract.Requires<RetryException>(retryCount < 5);

            if (DebugMode)
            {
                var tmpUri = requestUri.ToString();
                if (tmpUri.Contains("?")) tmpUri += "&_fake_status={0}".With(DebugResponse);
                else tmpUri += "?_fake_status={0}".With(DebugResponse);
                requestUri = new UriBuilder(tmpUri).Uri;
            }

            using (var request = new HttpRequestMessage(httpMethod, requestUri) {Content = postData})
            {
                if (Credentials != null)
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Credentials.AccessToken);
                using (var response = await StaticHttpClient.Client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                        return JsonSerializer.DeserializeFromStream<T>(await response.Content.ReadAsStreamAsync());
                    var statusCode = response.StatusCode;
                    switch (statusCode)
                    {
                        case HttpStatusCode.Forbidden:
                        case HttpStatusCode.Unauthorized:
                            await RefreshLogin();
                            return await Get<T>(requestUri, httpMethod, postData, retryCount + 1);
                        case HttpStatusCode.MethodNotAllowed:
                        case HttpStatusCode.BadGateway:
                        case HttpStatusCode.InternalServerError:
                            throw new ImgurDownException("Imgur is down, try the request again later.");
                        default:
                            Console.WriteLine(statusCode);
                            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                            throw new ImgurException("Unexpected HttpStatusCode encountered.");
                    }
                }
            }
        }

        public async Task<string> Get(Uri requestUri, HttpMethod httpMethod, HttpContent postData = null, int retryCount = 0)
        {
            Contract.Requires<RetryException>(retryCount < 5);
            
            using (var request = new HttpRequestMessage(httpMethod, requestUri) { Content = postData })
            {
                if (Credentials != null)
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Credentials.AccessToken);
                using (var response = await StaticHttpClient.Client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    var statusCode = response.StatusCode;
                    switch (statusCode)
                    {
                        case HttpStatusCode.Forbidden:
                        case HttpStatusCode.Unauthorized:
                            await RefreshLogin();
                            return await Get(requestUri, httpMethod, postData, retryCount + 1);
                        case HttpStatusCode.MethodNotAllowed:
                        case HttpStatusCode.BadGateway:
                            throw new ImgurDownException("Imgur is down, try the request again later.");
                        default:
                            Console.WriteLine(statusCode);
                            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                            throw new Exception("Unexpected HttpStatusCode encountered.");
                    }
                }
            }
        }

        private async Task<byte[]> GetImage(string requestUrl)
        {
            return await GetImage(new UriBuilder(requestUrl).Uri);
        }

        private async Task<byte[]> GetImage(Uri requestUri, int retryCount = 0)
        {
            Contract.Requires<RetryException>(retryCount < 5);

            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                if (Credentials != null)
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Credentials.AccessToken);
                using (var response = await StaticHttpClient.Client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsByteArrayAsync();
                    var statusCode = response.StatusCode;
                    switch (statusCode)
                    {
                        case HttpStatusCode.Forbidden:
                        case HttpStatusCode.Unauthorized:
                            await RefreshLogin();
                            return await GetImage(requestUri, retryCount + 1);
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
