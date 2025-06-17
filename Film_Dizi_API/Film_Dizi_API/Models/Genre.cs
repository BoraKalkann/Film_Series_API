namespace Film_Dizi_API.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public List<FilmGenre> FilmGenres { get; set; }
        public List<SeriesGenre> SeriesGenres { get; set; }
    }
}
