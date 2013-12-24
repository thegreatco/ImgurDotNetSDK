using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ImgurDotNetSDK.Extensions;

namespace ImgurDotNetSDK
{
    public partial class ImgurClient
    {
        public async Task<ImgurAlbum> Album(string albumId)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "Album Id cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album/{0}".ToUri(albumId);
            var model = await Get<DTO.AlbumResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AlbumEntity, ImgurAlbum>(model.Entity);
        }

        public async Task<ImgurImage[]> AlbumImages(string albumId)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "Album Id cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album/{0}/images".ToUri(albumId);
            var model = await Get<DTO.ImagesResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.ImageEntity[], ImgurImage[]>(model.Entity);
        }

        public async Task<ImgurAlbumIds> AlbumImage(string albumId, string imageId)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");
            if (string.IsNullOrWhiteSpace(imageId)) throw new ArgumentNullException("imageId", "The Image Id cannot be null.");

            var uri = "https://api.imgur.com/3/album/{0}/image/{1}".ToUri(albumId, imageId);
            var model = await Get<DTO.AlbumIdsResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AlbumIdsResponse, ImgurAlbumIds>(model);
        }

        public async Task<ImgurAlbum> CreateAlbum(string[] ids = null, string title = null, string description = null, ImgurPrivacy? privacy = null, ImgurLayout? layout = null, string cover = null)
        {
            var uri = "https://api.imgur.com/3/album/?";
            if (ids != null) uri += "ids[]={0}".With(ids.ValidatedJoin(","));
            if (!string.IsNullOrWhiteSpace(title)) uri += "title={0}".With(title);
            if (!string.IsNullOrWhiteSpace(description)) uri += "description={0}".With(description);
            if (privacy != null) uri += "privacy={0}".With(privacy.EnumToString());
            if (layout != null) uri += "layout={0}".With(layout.EnumToString());
            if (!string.IsNullOrWhiteSpace(cover)) uri += "cover={0}".With(cover);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
        }

        public async Task<long> UpdateAlbum(string albumId)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");

            var uri = "https://api.imgur.com/3/album/{0}".ToUri(albumId);
            var model = await Get<DTO.AlbumCountResponse>(uri, HttpMethod.Get);
            return model.Count;
        }

        public async Task<bool> DeleteAlbum(string albumId)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");

            var uri = "https://api.imgur.com/3/album/{0}".ToUri(albumId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Delete);
            return model.Response;
        }

        public async Task<bool> FavoriteAlbum(string albumId)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");

            var uri = "https://api.imgur.com/3/album/{0}/favorite".ToUri(albumId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }
    }
}
