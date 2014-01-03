using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(commentId), "CommentId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/comment/{0}".ToUri(commentId);
            var model = await Get<DTO.CommentResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.CommentEntity, ImgurComment>(model.Entity);
        }

        public async Task<bool> CreateComment(ImgurCreateComment comment)
        {
            Contract.Requires<ArgumentNullException>(comment != null, "Comment cannot be null.");

            var uri = "https://api.imgur.com/3/comment".ToUri(comment);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<bool> DeleteComment(ImgurComment comment)
        {
            Contract.Requires<ArgumentNullException>(comment != null, "Comment cannot be null.");

            return await DeleteComment(comment.Id);
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(commentId), "CommentId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/comment/{0}".ToUri(commentId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Delete);
            return model.Response;
        }

        public async Task<ImgurComment> CommentReplies(ImgurComment comment)
        {
            Contract.Requires<ArgumentNullException>(comment != null, "Comment cannot be null.");

            return await CommentReplies(comment.Id);
        }

        public async Task<ImgurComment> CommentReplies(string commentId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(commentId), "CommentId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/comment/{0}/replies".ToUri(commentId);
            var model = await Get<DTO.CommentResponse>(uri, HttpMethod.Get);
            return Mapper.Map<DTO.CommentEntity, ImgurComment>(model.Entity);
        }

        public async Task<bool> VoteComment(string commentId, ImgurVote vote)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(commentId), "CommentId cannot be null or whitespace.");
            Contract.Requires<ArgumentOutOfRangeException>(vote != default(ImgurVote), "Vote cannot be default value.");

            var uri = "https://api.imgur.com/3/comment/{0}/vote/{1}".ToUri(commentId, vote.EnumToString());
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<bool> ReportComment(string commentId)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(commentId), "CommentId cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/comment/{0}/report".ToUri(commentId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }

        public async Task<bool> ReplyComment(string commentId, ImgurReplyComment comment)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(commentId), "CommentId cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(comment != null, "Comment cannot be null.");
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(comment.Comment), "Comment content cannot be null or whitespace.");
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(comment.ImageId), "Comment Image Id cannot be null or whitespace.");

            var uri = "https://api.imgur.com/3/comment/{0}".ToUri(comment, commentId);
            var model = await Get<DTO.TrueFalseResponse>(uri, HttpMethod.Post);
            return model.Response;
        }
    }
}
