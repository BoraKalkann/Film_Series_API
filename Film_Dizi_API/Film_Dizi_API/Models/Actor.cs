using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
