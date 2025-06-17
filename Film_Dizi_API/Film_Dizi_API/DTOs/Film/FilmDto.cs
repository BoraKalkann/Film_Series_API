using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Film
{
    public class FilmDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null;
        public string Description { get; set; } = null;

        public DateTime? ReleaseDate { get; set; } = null;
        public int Duration { get; set; } 
        public string Director { get; set; }
        public decimal Rating { get; set; } 
    }
}
