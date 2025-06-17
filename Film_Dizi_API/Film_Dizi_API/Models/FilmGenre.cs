namespace Film_Dizi_API.Models
{
    public class FilmGenre
    {
        public int Id { get; set; }
        public Film? Film { get; set; }
        public int FilmId { get; set; }

        public Genre? Genre { get; set; }
        public int GenreID { get; set; }
    }
}
