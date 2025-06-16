using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } 
        public string Description { get; set; }
        public string PosterUrl { get; set; } = string.Empty;
        public string Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int Duration { get; set; } 
        public string Director { get; set; }
        public decimal Rating { get; set; }


        public List<Comment> Comments { get; set; } = new List<Comment>();
        
    }
}