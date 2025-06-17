using System.ComponentModel.DataAnnotations;

namespace Film_Dizi_API.DTOs.Account

{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
