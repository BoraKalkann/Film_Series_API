using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Actor
{
    public class UpdateActorDto
    {
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
