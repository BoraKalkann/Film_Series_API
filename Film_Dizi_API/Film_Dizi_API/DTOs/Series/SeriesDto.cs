using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Series
{
    public class SeriesDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Rating { get; set; } = 0;
        public int SeasonCount { get; set; } = 0;
        public int EpisodeCount { get; set; } = 0;
        public string Status { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;
    }
}
