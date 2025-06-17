using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Comment
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be bigger than 4 characters")]
        [MaxLength(280, ErrorMessage = "Title can't be over 280 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content must be bigger than 4 characters")]
        [MaxLength(280, ErrorMessage = "Content can't be over 280 characters")]
        public string Content { get; set; } = string.Empty;

    }
}
