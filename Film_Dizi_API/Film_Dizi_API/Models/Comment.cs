namespace Film_Dizi_API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? ActorId { get; set; }
        public Actor? Actor { get; set; }
        public int? SeriesId { get; set; }
        public Series? Series { get; set; }
    }
}
