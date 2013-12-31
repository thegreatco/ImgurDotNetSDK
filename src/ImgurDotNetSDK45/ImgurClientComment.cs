using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ImgurDotNetSDK
{
    public partial class ImgurClient
    {
        public async Task<ImgurComment> Comment(string commentId)
        {
            if (string.IsNullOrWhiteSpace(commentId)) throw new ArgumentNullException("commentId", "The Comment Id cannot be null.");

            var uri = "https://api.imgur.com/3/comment/{0}".ToUri(commentId);
            var model = await Get<DTO.CommentResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.CommentEntity, ImgurComment>(model.Entity);
        }

        public async Task<bool> CreateComment(ImgurCreateComment comment)
        {
            if (comment == null) throw new ArgumentNullException("comment", "The Comment cannot be null.");

            var uri = "https://api.imgur.com/3/comment".ToUri(comment);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<bool> DeleteComment(ImgurComment comment)
        {
            return await DeleteComment(comment.Id);
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            if (string.IsNullOrWhiteSpace(commentId)) throw new ArgumentNullException("commentId", "The Comment Id cannot be null.");

            var uri = "https://api.imgur.com/3/comment/{0}".ToUri(commentId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Delete);
            return model.Response;
        }

        public async Task<ImgurComment> CommentReplies(ImgurComment comment)
        {
            return await CommentReplies(comment.Id);
        }

        public async Task<ImgurComment> CommentReplies(string commentId)
        {
            if (string.IsNullOrWhiteSpace(commentId)) throw new ArgumentNullException("commentId", "The Comment Id cannot be null.");

            var uri = "https://api.imgur.com/3/comment/{0}/replies".ToUri(commentId);
            var model = await Get<DTO.CommentResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.CommentEntity, ImgurComment>(model.Entity);
        }

        public async Task<bool> VoteComment(string commentId, ImgurVote vote)
        {
            var uri = "https://api.imgur.com/3/comment/{0}/vote/{1}".ToUri(commentId, vote.EnumToString());
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<bool> ReportComment(string commentId)
        {
            var uri = "https://api.imgur.com/3/comment/{0}/report".ToUri(commentId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<bool> ReplyComment(string commentId, ImgurReplyComment comment)
        {
            if (string.IsNullOrWhiteSpace(commentId)) throw new ArgumentNullException("commentId", "The Comment Id cannot be null.");
            if (comment == null) throw new ArgumentNullException("comment", "The Comment cannot be null.");
            if (string.IsNullOrWhiteSpace(comment.Comment)) throw new ArgumentException("Comment text cannot be empty.");
            if (string.IsNullOrWhiteSpace(comment.ImageId)) throw new ArgumentException("Comment Image Id cannot be empty.");

            var uri = "https://api.imgur.com/3/comment/{0}".ToUri(comment, commentId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }
    }
}
