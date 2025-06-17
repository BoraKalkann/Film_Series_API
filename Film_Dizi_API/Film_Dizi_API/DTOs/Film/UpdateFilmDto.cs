using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Film
{
    public class UpdateFilmDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
    }
}
