using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using DotNetExtensions;

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

        public async Task<ImgurAlbum> CreateAlbum(ImgurAlbumProperties albumProps)
        {
            var uri = "https://api.imgur.com/3/album".ToUri(albumProps);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
        }

        [Obsolete("This overload of CreateAlbum shouldn't be used.  Use the one that takes an ImgurAlbumProperties object.")]
        public async Task<ImgurAlbum> CreateAlbum(string[] ids = null, string title = null, string description = null, ImgurPrivacy? privacy = null, ImgurLayout? layout = null, string cover = null)
        {
            return await CreateAlbum(new ImgurAlbumProperties { Ids = ids, Title = title, Description = description, Privacy = privacy, Layout = layout, Cover = cover });
        }

        public async Task<ImgurAlbum> UpdateAlbum(string albumId, ImgurAlbumProperties albumProps)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");

            var uri = "https://api.imgur.com/3/album".ToUri(albumProps);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
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

        public async Task<ImgurAlbum> SetAlbumImages(string albumId, string[] ids)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");
            if (ids == null) throw new ArgumentNullException("ids", "The list of picture Ids cannot be null.");

            return await UpdateAlbum(albumId, new ImgurAlbumProperties { Ids = ids });
        }

        public async Task<ImgurAlbum> AddAlbumImages(string albumId, string[] ids)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");
            if (ids == null) throw new ArgumentNullException("ids", "The list of picture Ids cannot be null.");

            var albumProps = new ImgurAlbumProperties { Ids = ids };
            var uri = "https://api.imgur.com/3/album/{0}/add".ToUri(albumProps, albumId);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
        }

        public async Task<ImgurAlbum> RemoveAlbumImages(string albumId, string[] ids)
        {
            if (string.IsNullOrWhiteSpace(albumId)) throw new ArgumentNullException("albumId", "The Album Id cannot be null.");
            if (ids == null) throw new ArgumentNullException("ids", "The list of picture Ids cannot be null.");

            var albumProps = new ImgurAlbumProperties { Ids = ids };
            var uri = "https://api.imgur.com/3/album/{0}/remove_images".ToUri(albumProps, albumId);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Delete);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
        }
    }
}
