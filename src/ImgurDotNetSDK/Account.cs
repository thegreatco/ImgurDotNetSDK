﻿using System;
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
            var uri = "https://api.imgur.com/3/account/{0}/settings".ToUri(username);

            var kvps = new List<KeyValuePair<string, string>>();
            if (!string.IsNullOrWhiteSpace(settings.Biography)) kvps.Add(new KeyValuePair<string, string>("bio", settings.Biography));
            if (settings.PublicImages != null) kvps.Add(new KeyValuePair<string, string>("public_images", settings.PublicImages.ToString()));
            if (settings.MessagingEnabled != null) kvps.Add(new KeyValuePair<string, string>("messaging_enabled", settings.MessagingEnabled.ToString()));
            if (settings.AlbumPrivacy != null) kvps.Add(new KeyValuePair<string, string>("album_privacy", settings.AlbumPrivacy.ToString()));
            if (settings.AcceptedGalleryTerms != null) kvps.Add(new KeyValuePair<string, string>("accepted_gallery_terms", settings.AcceptedGalleryTerms.ToString()));

            var postContent = new FormUrlEncodedContent(kvps);
            var model = await Get<DTO.BasicResponse>(uri, HttpMethod.Post, postContent);
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

        public async Task<bool> VerifyUsersEmail(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/verifyemail".ToUri(username);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Get);
            return model.Response;
        }

        public async Task<bool> SendVerificationEmail(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/verifyemail".ToUri(username);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<ImgurAlbum[]> Albums(string username = null, int page = 0)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/albums/{0}".ToUri(username, page);
            var model = await Get<DTO.AlbumsResponse>(uri, HttpMethod.Get);
            return model.Entity.Select(Mapper.Map<DTO.AlbumEntity, ImgurAlbum>).ToArray();
        }

        public async Task<ImgurAlbum> Album(string albumId, string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/album/{0}".ToUri(username, albumId);
            var model = await Get<DTO.AlbumResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AlbumEntity, ImgurAlbum>(model.Entity);
        }

        public async Task<ImgurAlbumIds> AlbumIds(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/albums/ids".ToUri(username);
            var model = await Get<DTO.AlbumIdsResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AlbumIdsResponse, ImgurAlbumIds>(model);
        }

        public async Task<long> AlbumCount(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/albums/ids".ToUri(username);
            var model = await Get<DTO.AlbumCountResponse>(uri, HttpMethod.Get);
            return model.Count;
        }

        public async Task<bool> DeleteAlbum(string albumId, string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/albums/{1}".ToUri(username, albumId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Delete);
            return model.Response;
        }

        public async Task<ImgurComment[]> Comments(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/comments".ToUri(username);
            var model = await Get<DTO.CommentsResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.CommentEntity[], ImgurComment[]>(model.Entity);
        }

        public async Task<ImgurComment> Comment(string commentId, string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/comment/{1}".ToUri(username, commentId);
            var model = await Get<DTO.CommentResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.CommentEntity, ImgurComment>(model.Entity);
        }

        public async Task<string[]> CommentIds(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/comments/ids".ToUri(username);
            var model = await Get<DTO.CommentIdsResponse>(uri, HttpMethod.Get);
            return model.CommentIds;
        }

        public async Task<long> CommentCount(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/comments/count".ToUri(username);
            var model = await Get<DTO.CommentCountResponse>(uri, HttpMethod.Get);
            return model.Count;
        }

        public async Task<bool> DeleteComment(string commentId, string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/comment/{1}".ToUri(username, commentId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Delete);
            return model.Response;
        }

        public async Task<ImgurImage[]> Images(string username = null, int page = 0)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/albums/{0}".ToUri(username, page);
            var model = await Get<DTO.ImagesResponse>(uri, HttpMethod.Get);
            return model.Entity.Select(Mapper.Map<DTO.ImageEntity, ImgurImage>).ToArray();
        }

        public async Task<ImgurImage> Image(string imageId = null, string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/image/{0}".ToUri(username, imageId);
            var model = await Get<DTO.ImageResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.ImageEntity, ImgurImage>(model.Entity);
        }

        public async Task<string[]> ImageIds(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/images/ids".ToUri(username);
            var model = await Get<DTO.ImageIdsResponse>(uri, HttpMethod.Get);
            return model.ImageIds;
        }

        public async Task<long> ImageCount(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/images/count".ToUri(username);
            var model = await Get<DTO.ImageCountResponse>(uri, HttpMethod.Get);
            return model.Count;
        }

        public async Task<bool> DeleteImage(string deleteHash, string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/images/{1}".ToUri(username, deleteHash);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Delete);
            return model.Response;
        }

        public async Task<ImgurNotification> Replies(bool newNotificationsOnly, string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/notifications/replies?new={1}".ToUri(username, newNotificationsOnly.ToString().ToLower());
            var model = await Get<DTO.NotificationsResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.NotificationEntity, ImgurNotification>(model.Entity);
        }
    }
}
