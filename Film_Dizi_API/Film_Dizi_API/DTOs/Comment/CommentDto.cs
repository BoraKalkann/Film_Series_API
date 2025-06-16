using Film_Dizi_API.Models;


namespace Film_Dizi_API.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? ActorId { get; set; }
        public int? SeriesId { get; set; }
    }
}
