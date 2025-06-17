using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.Models
{
    public class Series
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int SeasonCount { get; set; }
        public int EpisodeCount { get; set; }
        public string Status { get; set; }
        public string Creator {  get; set; }


        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Actor> Actors { get; set; } = new List<Actor> { };

        public List<Genre> Genres { get; set; } = new List<Genre>();
        
    }
}
