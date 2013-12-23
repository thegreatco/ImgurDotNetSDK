using System;
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
        /// <returns> A <see cref="ImgurImages"/> containing all the favorites. </returns>
        public async Task<ImgurImages> AccountGalleryFavorites(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/gallery_favorites".ToUri(username);
            var model = await Get<DTO.ImagesResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.ImagesResponse, ImgurImages>(model);
        }

        /// <summary>
        /// Get the Favorites for the account.  <see href="https://api.imgur.com/endpoints/account#account-favorites"/>
        /// </summary>
        /// <param name="username"> The username of the account.  If null, replaced with "me". </param>
        /// <returns></returns>
        public async Task<ImgurGallery> AccountFavorites(string username = null)
        {
            username = username ?? "me";
            var uri = "https://api.imgur.com/3/account/{0}/favorites".ToUri(username);
            var model = await Get<DTO.GalleryResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.GalleryResponse, ImgurGallery>(model);
        }
    }
}
