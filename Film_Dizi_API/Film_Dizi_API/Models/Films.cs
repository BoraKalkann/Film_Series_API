namespace Film_Dizi_API.Models
{
    public class Films
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Default value added
        public int ReleaseDate { get; set; }

    }
}