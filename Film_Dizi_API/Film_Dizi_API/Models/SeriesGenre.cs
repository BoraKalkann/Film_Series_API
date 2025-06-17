namespace Film_Dizi_API.Models
{
    public class SeriesGenre
    {
        public int Id { get; set; }
        public Series? Series { get; set; }
        public int SeriesId { get; set; }

        public Genre? Genre { get; set; }
        public int GenreID { get; set; }
    }
}
