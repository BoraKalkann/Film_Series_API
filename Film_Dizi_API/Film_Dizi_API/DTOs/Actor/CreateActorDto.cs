using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Actor
{
    public class CreateActorDto
    {
        [Required]
        [MaxLength(150, ErrorMessage = "Name can not be over 150 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Biography can not be over 500 characters")]
        public string Biography { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
