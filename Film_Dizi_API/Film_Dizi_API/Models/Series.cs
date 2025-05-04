namespace Film_Dizi_API.Models
{
    namespace Film_Dizi_API.Models
    {
        public class Series
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty; 
            public int Seasons { get; set; }
            public string Publisher { get; set; } = string.Empty;

            public string Genre { get; set; } = string.Empty;

            public double Rating { get; set; }
        }
    }

}
