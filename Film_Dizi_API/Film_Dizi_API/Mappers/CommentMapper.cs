using Film_Dizi_API.DTOs.Comment;
using Film_Dizi_API.Models;
using System.Runtime.CompilerServices;

namespace Film_Dizi_API.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                ActorId = commentModel.ActorId,
                SeriesId = commentModel.SeriesId,
                
            };
        }

        public static Comment ToCommentCreateFromDto(this CreateCommentDto commentDto, int actorId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                ActorId = actorId
            };
        }
        public static Comment ToCommentUpdateFromDto(this UpdateCommentDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content
            };
        }
    }
}
