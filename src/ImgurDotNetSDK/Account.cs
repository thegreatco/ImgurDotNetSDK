using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ImgurDotNetSDK.Extensions;

namespace ImgurDotNetSDK
{
    public partial class ImgurClient
    {
        /// <summary>
        /// Get the Account Base data. <see href="https://api.imgur.com/endpoints/account#account"/>
        /// </summary>
        /// <param name="username"> The username of the account.  If null, replaced with "me". </param>
        /// <returns> An <see cref="ImgurAccount"/>. </returns>
        public async Task<ImgurAccount> AccountBase(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}".ToUri(username);
            var model = await Get<DTO.AccountResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AccountResponse, ImgurAccount>(model);
        }

        /// <summary>
        /// Create a new Imgur account. <see href="https://api.imgur.com/endpoints/account#account-create"/>
        /// </summary>
        /// <param name="username"> The username of the account to create. </param>
        /// <returns> An <see cref="ImgurAccount"/>. </returns>
        public async Task<ImgurAccount> CreateAccount(string username = null)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username", "The username cannot be null.");
            var uri = "https://api.imgur.com/3/account/{0}".ToUri(username);
            var model = await Get<DTO.AccountResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.AccountResponse, ImgurAccount>(model);
        }

        /// <summary>
        /// Delete an Imgur account.  <see href="https://api.imgur.com/endpoints/account#account-delete"/>
        /// </summary>
        /// <param name="username"> The username of the account to delete. </param>
        /// <returns> An <see cref="ImgurBasic"/> response.  Check the returned object for success of operation. </returns>
        public async Task<ImgurBasic> DeleteAccount(string username = null)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException("username", "The username cannot be null.");
            var uri = "https://api.imgur.com/3/account/{0}".ToUri(username);
            var model = await Get<DTO.BasicResponse>(uri, HttpMethod.Delete);
            return Mapper.Map<DTO.BasicResponse, ImgurBasic>(model);
        }

        /// <summary>
        /// Get the Gallery Favorites for the account.  <see href="https://api.imgur.com/endpoints/account#account-gallery-favorites"/>
        /// </summary>
        /// <param name="username"> The username of the account.  If null, replaced with "me". </param>
        /// <returns> An array of <see cref="ImgurImage"/> containing all the favorites. </returns>
        public async Task<ImgurImage[]> AccountGalleryFavorites(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/gallery_favorites".ToUri(username);
            var model = await Get<DTO.ImagesResponse>(uri, HttpMethod.Get);
            return model.Entity.Select(Mapper.Map<DTO.ImageEntity, ImgurImage>).ToArray();
        }

        /// <summary>
        /// Get the Favorites for the account.  <see href="https://api.imgur.com/endpoints/account#account-favorites"/>
        /// </summary>
        /// <param name="username"> The username of the account.  If null, replaced with "me". </param>
        /// <returns> An array of <see cref="ImgurGallery"/> containing all the favorites. </returns>
        public async Task<ImgurGallery[]> AccountFavorites(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/favorites".ToUri(username);
            var model = await Get<DTO.GalleryResponse>(uri, HttpMethod.Get);
            return model.Entity.Select(Mapper.Map<DTO.GalleryEntity, ImgurGallery>).ToArray();
        }

        /// <summary>
        /// Get the Submissions for the account.  <see href="https://api.imgur.com/endpoints/account#account-submissions"/>
        /// </summary>
        /// <param name="username"> The username of the account.  If null, replaced with "me". </param>
        /// <param name="page"> The page number to get. </param>
        /// <returns> An array of <see cref="ImgurGallery"/> containing all the favorites. </returns>
        public async Task<ImgurGallery[]> AccountSubmissions(string username = null, int page = 0)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/submissions/{0}".ToUri(username, page);
            var model = await Get<DTO.GalleryResponse>(uri, HttpMethod.Get);
            return model.Entity.Select(Mapper.Map<DTO.GalleryEntity, ImgurGallery>).ToArray();
        }

        /// <summary>
        /// Get the settings for the account.  <see href="https://api.imgur.com/endpoints/account#account-settings"/>
        /// </summary>
        /// <param name="username"> The username of the account.  If null, replaced with "me". </param>
        /// <returns> A <see cref="ImgurAccountSettings"/>. </returns>
        public async Task<ImgurAccountSettings> AccountSettings(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/settings".ToUri(username);
            var model = await Get<DTO.AccountSettingsResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AccountSettingsEntity, ImgurAccountSettings>(model.Entity);
        }

        /// <summary>
        /// Set the settings for the account.  <see href="https://api.imgur.com/endpoints/account#update-settings"/>
        /// </summary>
        /// <param name="settings"> The <see cref="ImgurAccountSettings"/>.  Any settings that should not be changed should be null. </param>
        /// <param name="username"> The username of the account.  If null, replaced with "me". </param>
        /// <returns> A <see cref="ImgurBasic"/> indicating the success of the operation. </returns>
        public async Task<ImgurBasic> ChangeAccountSettings(ImgurAccountSettings settings, string username = null)
        {
            username = username ?? "me";
            var kvps = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(settings.Biography)) kvps.Add(new KeyValuePair<string, string>("bio", settings.Biography));
            if (settings.PublicImages != null) kvps.Add(new KeyValuePair<string, string>("public_images", settings.PublicImages.ToString()));
            if (settings.MessagingEnabled != null) kvps.Add(new KeyValuePair<string, string>("messaging_enabled", settings.MessagingEnabled.ToString()));
            if (settings.AlbumPrivacy != null) kvps.Add(new KeyValuePair<string, string>("album_privacy", settings.AlbumPrivacy.ToString()));
            if (settings.AcceptedGalleryTerms != null) kvps.Add(new KeyValuePair<string, string>("accepted_gallery_terms", settings.AcceptedGalleryTerms.ToString()));
            var postContent = new FormUrlEncodedContent(kvps);
            var model = await Get<DTO.BasicResponse>("https://api.imgur.com/3/account/{0}/settings".ToUri(username), HttpMethod.Post, postContent);
            return Mapper.Map<DTO.BasicResponse, ImgurBasic>(model);
        }

        public async Task<ImgurAccountStatistics> AccountStatistics(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/stats".ToUri(username);
            var model = await Get<DTO.AccountStatisticsResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AccountStatisticsEntity, ImgurAccountStatistics>(model.Entity);
        }

        public async Task<ImgurGalleryProfile> AccountGalleryProfile(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/gallery_profile".ToUri(username);
            var model = await Get<DTO.GalleryProfileResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.GalleryProfileEntity, ImgurGalleryProfile>(model.Entity);
        }

        public async Task<ImgurVerifyEmail> VerifyUsersEmail(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/verifyemail".ToUri(username);
            var model = await Get<DTO.VerifyEmailResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.VerifyEmailResponse, ImgurVerifyEmail>(model);
        }

        public async Task<ImgurVerifyEmail> SendVerificationEmail(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/verifyemail".ToUri(username);
            var model = await Get<DTO.VerifyEmailResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.VerifyEmailResponse, ImgurVerifyEmail>(model);
        }

        public async Task<ImgurAlbum> Albums(string username = null, int page = 0)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/albums/{0}".ToUri(username, page);
            var model = await Get<DTO.AlbumResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AlbumResponse, ImgurAlbum>(model);
        }
    }
}
