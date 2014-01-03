using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;

namespace ImgurDotNetSDK
{
    public partial class ImgurClient
    {
        public async Task<ImgurAlbum> Album(string albumId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album/{0}".ToUri(albumId);
            var model = await Get<DTO.AlbumResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AlbumEntity, ImgurAlbum>(model.Entity);
        }

        public async Task<ImgurImage[]> AlbumImages(string albumId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album/{0}/images".ToUri(albumId);
            var model = await Get<DTO.ImagesResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.ImageEntity[], ImgurImage[]>(model.Entity);
        }

        public async Task<ImgurAlbumIds> AlbumImage(string albumId, string imageId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(imageId), "ImageId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album/{0}/image/{1}".ToUri(albumId, imageId);
            var model = await Get<DTO.AlbumIdsResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.AlbumIdsResponse, ImgurAlbumIds>(model);
        }

        public async Task<ImgurAlbum> CreateAlbum(ImgurAlbumProperties albumProps)
        {
            Contract.Requires<ArgumentNullException>(albumProps != null, "Album Properties cannot be null.");

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
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album".ToUri(albumProps);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
        }

        public async Task<bool> DeleteAlbum(string albumId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album/{0}".ToUri(albumId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Delete);
            return model.Response;
        }

        public async Task<bool> FavoriteAlbum(string albumId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/album/{0}/favorite".ToUri(albumId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<ImgurAlbum> SetAlbumImages(string albumId, string[] ids)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(ids != null, "ImageIds array cannot be null.");
            Contract.Requires<ArgumentNullException>(Contract.ForAll(ids, x => !string.IsNullOrWhiteSpace(x)), "ImageId cannot be null or whitespace.");

            return await UpdateAlbum(albumId, new ImgurAlbumProperties { Ids = ids });
        }

        public async Task<ImgurAlbum> AddAlbumImages(string albumId, string[] ids)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(ids != null, "ImageIds array cannot be null.");
            Contract.Requires<ArgumentNullException>(Contract.ForAll(ids, x => !string.IsNullOrWhiteSpace(x)), "ImageId cannot be null or whitespace.");

            var albumProps = new ImgurAlbumProperties { Ids = ids };
            var uri = "https://api.imgur.com/3/album/{0}/add".ToUri(albumProps, albumId);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Post);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
        }

        public async Task<ImgurAlbum> RemoveAlbumImages(string albumId, string[] ids)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(albumId), "AlbumId cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(ids != null, "ImageIds array cannot be null.");
            Contract.Requires<ArgumentNullException>(Contract.ForAll(ids, x => !string.IsNullOrWhiteSpace(x)), "ImageId cannot be null or whitespace.");

            var albumProps = new ImgurAlbumProperties { Ids = ids };
            var uri = "https://api.imgur.com/3/album/{0}/remove_images".ToUri(albumProps, albumId);
            var model = await Get<DTO.CreateAlbumResponse>(uri, HttpMethod.Delete);
            return Mapper.Map<DTO.CreateAlbumEntity, ImgurAlbum>(model.Entity);
        }
    }
}
