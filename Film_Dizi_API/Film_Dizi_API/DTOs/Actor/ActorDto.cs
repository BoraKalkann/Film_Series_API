using Film_Dizi_API.DTOs.Comment;
using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Actor
{
    public class ActorDto
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
